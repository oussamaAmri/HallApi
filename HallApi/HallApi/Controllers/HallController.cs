using HallDomain.Interfaces;
using HallDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HallApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        /*        [HttpGet]
                public IEnumerable<string> Get()
                {
                    return new List<string>() { "Salle 1", "Salle 2" , "Salle 3" };
                }
        */

        private readonly IHallService _ihallService;
        public HallController(IHallService ihallService)
        {
            _ihallService= ihallService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return _ihallService.GetHalls().ToList();
        }
    }
}
