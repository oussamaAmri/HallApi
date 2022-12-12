using HallApi.Dtos.Requests;
using HallApi.Dtos.Responses;
using HallDal;
using HallDomain.Interfaces;
using HallDomain.Models;
using HallDomain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HallApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class HallController : ControllerBase
    {
        /*        [HttpGet]
public IEnumerable<string> Get()
{
return new List<string>() { "Salle 1", "Salle 2" , "Salle 3" };
}
*/
        private readonly IHallService _hallService;
        //        private readonly FuwearContext _db;

        public HallController(IHallService ihallService)
        {
            _hallService = ihallService;
        }

        [HttpGet("Halls")]
        public async Task<IActionResult> GetHallsAsync()
        {
            IEnumerable<Hall> hall = await _hallService.GetHallsAsync();
            return Ok(new HallsResponse
            {
                Halls = hall.Select(h => new Dtos.HallDto
                {
                    Id = h.Id,
                    Name = h.Name
                })
            });
        }

        [HttpGet("Halls/{id}")]

        public async Task<IActionResult> GetHallsByIdAsync([FromRoute] int id)
        {

            var hall = await _hallService.GetHallsByIdAsync(id);
            if (hall == null)
            {
                return NotFound();
            }

            return Ok(new HallResponse
            {
                Hall = new Dtos.HallDto { Id = hall.Id, Name = hall.Name }
            });
        }
        [HttpPost("Halls")]
        public async Task<IActionResult> AddHallsAsync([FromBody] CreateHallRequest createHallRequest)
        {
            var hall = new Hall { Name = createHallRequest.RoomName };
            var addroom = await _hallService.AddHallsAsync(hall);
            return this.StatusCode(201, new CreateHallResponse
            {
                CreatedHall = new Dtos.HallDto { Id = addroom.Id, Name = addroom.Name }
            });
        }
        [HttpPost("Halls/{id}")]
        public async Task<IActionResult> UpdateHallsAsync([FromRoute] int id, [FromBody] UpdateHallRequest updateHallRequest)
        {
            var room = new Hall { Name = updateHallRequest.RoomName };
            var updateRoom = await _hallService.UpdateHallsAsync(id, room);
            if (updateRoom == null)
            {
                return NotFound();
            }
            else
            {
                return this.Ok(new UpdateHallResponse
                {
                    UpdateHall = new Dtos.HallDto { Id = updateRoom.Id, Name = updateRoom.Name }
                });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHallsAsync([FromRoute] int id)
        {

            var hall = await _hallService.DeleteHallsAsync(id);
            if (hall == null)
            {
                return NotFound();
            }

            return Ok(new HallResponse
            {
                Hall = new Dtos.HallDto { Id = hall.Id, Name = hall.Name }
            });
        }

    }
}
