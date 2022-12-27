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
  public class UserMappingProfile : Profile
  {
    public UserMappingProfile()
    {
      CreateMap<UserDTO, User>();
      CreateMap<User, UserDTO>();
    }
  }
}
