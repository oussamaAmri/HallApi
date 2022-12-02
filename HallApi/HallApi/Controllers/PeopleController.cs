using HallApi.Dtos.Requests;
using HallApi.Dtos.Responses;
using HallDomain.Interfaces;
using HallDomain.Models;
using HallDomain.Services;
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
        public async Task<IActionResult> GetPeopleAsync()
        {
            IEnumerable<People> people = await _peopleService.GetPeopleAsync();
            return Ok(new PeoplesResponse
            {
                Peoples = people.Select(p => new Dtos.PeopleDto
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName
                })
            });
        }

        [HttpPost("Personnes")]
        public async Task<IActionResult> AddPeoplesAsync([FromBody] CreatePeopleRequest createPeopleRequest)
        {
            var people = new People { FirstName = createPeopleRequest.FirstName , LastName = createPeopleRequest.LastName };
            var addpeople = await _peopleService.AddPeoplesAsync(people);
            return this.StatusCode(201, new CreatePeopleResponse
            {
                CreatedPeople = new Dtos.PeopleDto { Id = addpeople.Id, FirstName = addpeople.FirstName, LastName =addpeople.LastName }
            });
        }
    }
}
 