using LibraryAPI.Data;
using LibraryAPI.DTOs;
using LibraryAPI.Models;
using LibraryAPI.Repositories.Abstract;
using LibraryAPI.Shared.Helper;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories.Concrete
{
  public class ReservationRepository : IReservationRepository
  {
    private readonly LibraryContext _context;
    private readonly IBookRepository _bookRepository;

    public ReservationRepository(LibraryContext context, IBookRepository bookRepository)
    {
      _context = context;
      _bookRepository = bookRepository;
    }

    public async Task Add(Reservation entity)
    {
      try
      {
        var user = await _context.Users.FindAsync(entity.UserId);
        if (user == null)
        {
          ServiceResult.Error("User not found.");
        }

        var book = await _context.Books.FindAsync(entity.BookId);
        if (book == null)
        {
          ServiceResult.Error("Book not found.");
        }

        if (book.Amount == 0)
        {
          ServiceResult.Error("Book is not available.");
        }

        if (user.Reservations.Count >= 3)
        {
          ServiceResult.Error("User has reached the maximum number of reservations.");
        }

        int reservationCount = _context.Reservations.Count(r => r.UserId == entity.UserId);
        if (reservationCount >= 3)
          throw new Exception("Reservation count can not be greater than 3");

        _context.Reservations.Add(entity);
        await _context.SaveChangesAsync();
        //
        Book updateBook = await _context.Books.FirstOrDefaultAsync(b => b.Id == entity.BookId);
        updateBook.Amount--;
        await _bookRepository.Update(updateBook);
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public async Task Delete(Reservation entity)
    {
      var user = await _context.Users.FindAsync(entity.UserId);
      if (user == null)
      {
        ServiceResult.Error("User not found.");
      }

      var book = await _context.Books.FindAsync(entity.BookId);
      if (book == null)
      {
        ServiceResult.Error("Book not found.");
      }

      var model = user.Reservations.FirstOrDefault(r => r.BookId == book.Id);
      if (model == null)
      {
        ServiceResult.Error("Book is not reserved by this user.");
      }

      _context.Reservations.Remove(entity);
      await _context.SaveChangesAsync();
      //
      Book updateBook = await _context.Books.FirstOrDefaultAsync(b => b.Id == entity.BookId);
      updateBook.Amount++;
      await _bookRepository.Update(updateBook);
    }

    public async Task<List<Reservation>> GetAll()
    {
      return await _context.Reservations.ToListAsync();
    }

    public async Task<Reservation> GetById(int Id)
    {
      return await _context.Reservations.FirstOrDefaultAsync(z => z.Id == Id);
    }

    public async Task<int> GetReservationCount(int userId)
    {
      return await _context.Reservations.CountAsync(r => r.UserId == userId);
    }
    public async Task Update(Reservation entity)
    {
      Reservation updateReservation = await _context.Reservations.FirstOrDefaultAsync(z => z.Id == entity.Id);
      updateReservation.UserId = entity.UserId;
      updateReservation.User = entity.User;
      updateReservation.BookId = entity.BookId;
      updateReservation.Book = entity.Book;
      updateReservation.ReserveDate = entity.ReserveDate;
      updateReservation.ReturnDate = entity.ReturnDate;

      await _context.SaveChangesAsync();
    }
  }
}
