using LibraryAPI.DTOs;
using LibraryAPI.Models;
using LibraryAPI.Repositories.Abstract;
using LibraryAPI.Services.Abstract;
using LibraryAPI.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Services.Concrete
{
  public class ReservationService : IReservationService
  {
    private readonly IReservationRepository _reservationRepository;
    public ReservationService(IReservationRepository reservationRepository)
    {
      _reservationRepository = reservationRepository;
    }

    public async Task Add(Reservation entity)
    {
      await _reservationRepository.Add(entity);
    }

    public async Task Delete(Reservation entity)
    {
      await _reservationRepository.Delete(entity);
    }

    public async Task<List<Reservation>> GetAll()
    {
      return await _reservationRepository.GetAll();
    }

    public async Task<Reservation> GetById(int Id)
    {
      return await _reservationRepository.GetById(Id);
    }

    public async Task<int> GetReservationCount(int userId)
    {
      return await _reservationRepository.GetReservationCount(userId);
    }

    public async Task Update(Reservation entity)
    {
      await _reservationRepository.Update(entity);
    }
  }
}
