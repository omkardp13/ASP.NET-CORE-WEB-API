using Microsoft.AspNetCore.Mvc;
using CustomValidationExample.Models;

namespace CustomValidationExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Normally, save the product to the database here.

            return Ok(product);
        }
    }
}
