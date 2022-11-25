using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HallApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>() { "Salle 1", "Salle 2" , "Salle 3" };
        }
    }
}
