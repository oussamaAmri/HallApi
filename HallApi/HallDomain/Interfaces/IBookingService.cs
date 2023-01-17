using HallDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallDomain.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetReservationsAsync();
        Task<ResultCreationBooking> AddReservationAsync(Booking reservation);
        Task<IEnumerable<Booking>> GetReservationByIdAsync(int roomId);
        Task<IEnumerable<Booking>> GetReservationByRommAndByDate(SearchBooking searchBooking);
        Task<Booking> DeleteBookingsAsync(int id);
    }
}
