using System.ComponentModel.DataAnnotations;

namespace HallApi.Dtos.Requests
{
    public class CreatePeopleRequest
    {
        [Required(ErrorMessage = "Le champ est vide")]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
