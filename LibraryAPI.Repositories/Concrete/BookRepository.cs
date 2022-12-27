using LibraryAPI.Data;
using LibraryAPI.Models;
using LibraryAPI.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories.Concrete
{
  public class BookRepository : IBookRepository
  {
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
      _context = context;
    }
    public async Task Add(Book entity)
    {
      _context.Books.Add(entity);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(Book entity)
    {
      _context.Books.Remove(entity);
     await _context.SaveChangesAsync();
    }

    public async Task<List<Book>> GetAll()
    {
      return await _context.Books.ToListAsync();
    }

    public async Task<Book> GetById(int Id)
    {
      return await _context.Books.FirstOrDefaultAsync(z => z.Id == Id);
    }

    public async Task Update(Book entity)
    {
      Book updateBook = await _context.Books.FirstOrDefaultAsync(z => z.Id == entity.Id);
      updateBook.Title = entity.Title;
      updateBook.Author = entity.Author;
      updateBook.Amount = entity.Amount;
      updateBook.Reservations = entity.Reservations;

      await _context.SaveChangesAsync();
    }
  }
}
