using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        private readonly IGreetingService _greetingService;

        public HelloController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var greeting = _greetingService.Greet(name);
            return Ok(greeting);
        }
    }
}
