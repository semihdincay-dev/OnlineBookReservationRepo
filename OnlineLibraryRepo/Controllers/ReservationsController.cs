using AutoMapper;
using LibraryAPI.DTOs;
using LibraryAPI.Models;
using LibraryAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReservationsController : ControllerBase
  {
    private readonly IReservationService _reservationService;
    private readonly IMapper _mapper;

    public ReservationsController(IReservationService reservationService,IMapper mapper)
    {
      _reservationService = reservationService;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservations()
    {
      var reservations = await _reservationService.GetAll();
      return Ok(_mapper.Map<IEnumerable<ReservationDTO>>(reservations));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReservationDTO>> GetReservation(int id)
    {
      var reservation = await _reservationService.GetById(id);
      if (reservation == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<ReservationDTO>(reservation));
    }

    [HttpPost]
    public async Task<ActionResult<ReservationDTO>> AddReservation(ReservationDTO reservationDTO)
    {
      var reservation = _mapper.Map<Reservation>(reservationDTO);
      await _reservationService.Add(reservation);
      return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReservation(int id, ReservationDTO reservationDTO)
    {
      var reservation = _mapper.Map<Reservation>(reservationDTO);
      if (id != reservation.Id)
      {
        return BadRequest();
      }
      await _reservationService.Update(reservation);
      return NoContent();
    }

    [HttpDelete("{id}/return")]
    public async Task<IActionResult> DeleteReservation(int id)
    {
      var reservation = await _reservationService.GetById(id);
      if (reservation == null)
      {
        return NotFound();
      }
      await _reservationService.Delete(reservation);
      return NoContent();
    }

    [HttpGet("{id}/count")]
    public async Task<ActionResult<int>> GetReservationCount(int userId)
    {
      var reservation = await _reservationService.GetReservationCount(1);
      return Ok(_mapper.Map<int>(reservation));
    }

  }
}
