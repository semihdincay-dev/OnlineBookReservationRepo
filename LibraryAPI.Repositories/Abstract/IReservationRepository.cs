using LibraryAPI.DTOs;
using LibraryAPI.Models;
using LibraryAPI.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories.Abstract
{
  public interface IReservationRepository : IRepository<Reservation>
  {
    Task<int> GetReservationCount(int userId);
  }
}
