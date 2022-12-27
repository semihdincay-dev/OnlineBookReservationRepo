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
  public class ReservationMappingProfile : Profile
  {
    public ReservationMappingProfile()
    {
      CreateMap<ReservationDTO, Reservation>();
      CreateMap<Reservation, ReservationDTO>()
        .ForMember(
          dest => dest.UserName,
          opt => opt.MapFrom(src => src.User.Name))
        .ForMember(
          dest => dest.BookTitle,
          opt => opt.MapFrom(src => src.Book.Title)
        );
    }
  }
}
