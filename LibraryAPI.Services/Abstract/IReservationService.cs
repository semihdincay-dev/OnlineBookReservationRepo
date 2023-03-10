using LibraryAPI.DTOs;
using LibraryAPI.Models;
using LibraryAPI.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Services.Abstract
{
  public interface IReservationService : IService<Reservation>
  {
    Task<int> GetReservationCount(int userId);
  }
}
