using HallDomain.Interfaces;
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

        public HallController(IHallService ihallService)
        {
            _hallService = ihallService;
        }

        [HttpGet("Halls")]
        public async Task<IActionResult> GetHallsAsync()
        {
            IEnumerable<string> hall = await _hallService.GetHallsAsync();
            return Ok(hall);
        }
    }
}
