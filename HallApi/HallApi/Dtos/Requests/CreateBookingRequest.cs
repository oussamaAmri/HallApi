using System.ComponentModel.DataAnnotations;

namespace HallApi.Dtos.Requests
{
    public class CreateBookingRequest
    {
        [Required(ErrorMessage = "Le champ est vide")]
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Le champ est vide")]
        public int PersonId { get; set; }
        [Required(ErrorMessage = "Le champ est vide")]
        public DateTime BookingDate { get; set; }
        [Required(ErrorMessage = "Le champ est vide")]
        public int StartSlot { get; set; }
        [Required(ErrorMessage = "Le champ est vide")]
        public int EndSlot { get; set; }
    }
}
