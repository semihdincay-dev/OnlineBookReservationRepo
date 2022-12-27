using AutoMapper;
using LibraryAPI.DTOs;
using LibraryAPI.Models;
using LibraryAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BooksController : ControllerBase
  {
    private readonly IBookService _bookService;
    private readonly IReservationService _reservationService;
    private readonly IMapper _mapper;

    public BooksController(IBookService bookService, IMapper mapper, IReservationService reservationService)
    {
      _bookService = bookService;
      _mapper = mapper;
      _reservationService = reservationService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
    {
      try
      {
        var books = await _bookService.GetAll();
        var mappedBooks = _mapper.Map<IEnumerable<BookDTO>>(books);
        return Ok(mappedBooks);
      }
      catch (Exception ex)
      {
        throw new Exception("Getiremedim");
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBookById(int id)
    {
      var book = await _bookService.GetById(id);
      if (book == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<BookDTO>(book));
    }

    [HttpPost]
    public async Task<ActionResult<Book>> AddBook(BookDTO bookDTO)
    {
      var book = _mapper.Map<Book>(bookDTO);
      await _bookService.Add(book);
      return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
    }

    [HttpPut("{id}/reserve")]
    public async Task<IActionResult> UpdateBook(BookDTO bookDTO)
    {
      if (bookDTO.Id == 0)
      {
        return BadRequest();
      }
      var book = _mapper.Map<Book>(bookDTO);
      await _bookService.Update(book);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
      var book = await _bookService.GetById(id);
      if (book == null)
      {
        return NotFound();
      }
      await _bookService.Delete(book);
      return NoContent();
    }
  }
}
