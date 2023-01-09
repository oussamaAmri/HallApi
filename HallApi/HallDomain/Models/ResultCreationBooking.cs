using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallDomain.Models
{
    public class ResultCreationBooking
    {
        public List<string> ErrorMSG { get; set; } = new List<string>();
        public IEnumerable<Slot> ListReservation { get; set; } = new List<Slot>();

        public Booking booking { get; set; }
    }
}
