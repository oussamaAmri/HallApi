using System.ComponentModel.DataAnnotations;

namespace HallApi.Dtos.Requests
{
    public class CreateHallRequest
    {
        [Required(ErrorMessage ="Le champ est vide")]
        public string RoomName { get; set; }
    }
}
