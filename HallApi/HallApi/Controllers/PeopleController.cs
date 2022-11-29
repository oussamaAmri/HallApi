using HallDomain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HallApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController (IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("Personnes")]
        public IActionResult GetPeople()
        {
            return Ok(_peopleService.GetPeople().ToList());
        }
    }
}
