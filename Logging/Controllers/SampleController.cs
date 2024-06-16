using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Logging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Log.Information("This is an information log");
            Log.Warning("This is a warning log");

            try
            {
                throw new Exception("This is a test exception");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while processing the request");
                return StatusCode(500, "Internal server error");
            }

            return Ok("Hello, world!");
        }
    }
}
