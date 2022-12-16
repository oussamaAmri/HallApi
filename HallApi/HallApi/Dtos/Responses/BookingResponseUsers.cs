using HallDomain.Models;

namespace HallApi.Dtos.Responses
{
    public class BookingResponseUsers
    {
        public String message { get; set; }
        public BookingDto infoReservation { get; set; }
        public IEnumerable<SlotDto> listesCreneux { get; set; }
    }
}
