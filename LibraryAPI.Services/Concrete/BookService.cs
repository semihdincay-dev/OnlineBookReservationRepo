using LibraryAPI.Data;
using LibraryAPI.Models;
using LibraryAPI.Repositories.Abstract;
using LibraryAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Services.Concrete
{
  public class BookService : IBookService
  {
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
      _bookRepository = bookRepository;
    }
    public async Task Add(Book entity)
    {
      await _bookRepository.Add(entity);
    }

    public async Task Delete(Book entity)
    {
      await _bookRepository.Delete(entity);
    }

    public async Task<List<Book>> GetAll()
    {
      return await _bookRepository.GetAll();
    }

    public async Task<Book> GetById(int Id)
    {
      return await _bookRepository.GetById(Id);
    }

    public async Task Update(Book entity)
    {
      await _bookRepository.Update(entity);
    }
  }
}
