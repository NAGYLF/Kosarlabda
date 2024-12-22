using Kosarlabda.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kosarlabda.Controllers
{
    [Route("api/Data")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Data> Get()
        {
            using (var context = new TeamContext())
            {
                return StatusCode(200, context.Data.ToList());
            }
        }

    }
}
