using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PracticeConcepts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
     
        public ProductsController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            throw new Exception("Test exception");
            // Simulated data retrieval
            var products = new[] {
                new { Id = 1, Name = "Product1", Price = 10.0 },
                new { Id = 2, Name = "Product2", Price = 20.0 }
            };
            return Ok(products);
        }
    }
}
