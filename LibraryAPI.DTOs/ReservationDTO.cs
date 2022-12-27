using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DTOs
{
  public class ReservationDTO
  {
    public int Id { get; set; }
    public DateTime ReserveDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public string BookTitle { get; set; }
    public string UserName { get; set; }
  }
}
