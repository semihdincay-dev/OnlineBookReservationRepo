using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
  public class Reservation
  {
    public int Id { get; set; }
    public DateTime ReserveDate { get; set; }
    public DateTime ReturnDate { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; }

    public int BookId { get; set; }
    public virtual Book Book { get; set; }
  }
}
