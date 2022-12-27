using AutoMapper;
using LibraryAPI.DTOs;
using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Data.AutoMapper
{
  public class BookMappingProfile : Profile
  {
    public BookMappingProfile()
    {
      CreateMap<BookDTO, Book>();
      CreateMap<Book,BookDTO>();
    }
  }
}
