using HallDal;
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
        private readonly FuwearContext _db;

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
 /*       [HttpPost("AddHals")]
               public async Task <ActionResult<Room>> AddHallsAsync()
               {
                       IEnumerable<string> addroom = await _hallService.AddHallsAsync();
                       return Ok(addroom);
               }*/
    }
}
