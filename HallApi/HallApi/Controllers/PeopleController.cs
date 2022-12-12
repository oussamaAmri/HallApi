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
        [HttpGet("Personnes/{id}")]
        public async Task<IActionResult> GetPeopleByIdAsync([FromRoute] int id)
        {

            var people = await _peopleService.GetPeopleByIdAsync(id);
            if (people == null)
            {
                return NotFound();
            }

            return Ok(new PeopleResponse
            {
                  People = new Dtos.PeopleDto { Id = people.Id,FirstName = people.FirstName,LastName = people.LastName}
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
        [HttpPut("Personnes/{id}")]

        public async Task<IActionResult> UpdatePeoplesAsync([FromRoute] int id,[FromBody] UpdatePeopleRequest updatePeopleRequest)
        {
            var people = new People { FirstName = updatePeopleRequest.FirstName , LastName = updatePeopleRequest.LastName };
            var updatePeople = await _peopleService.UpdatePeoplesAsync(id,people);
            if (updatePeople == null)
            {
                return NotFound();
            }
            else
            {
                return this.Ok(new UpdatePeopleResponse
                {
                    UpdatePeople = new Dtos.PeopleDto { Id = updatePeople.Id, FirstName = updatePeople.FirstName, LastName = updatePeople.LastName }
                });
            }
        }
    }
}
 