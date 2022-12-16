using HallDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallDomain.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetReservationsAsync();
        Task<Booking> AddReservationAsync(Booking reservation);
    }
}
