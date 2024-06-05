using DemoPractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoPractice.Controllers
{

    /*
     * http://localhost:5000/api/products (default sorting by Id)
     *  http://localhost:5000/api/products?sortBy=name (sorting by Name)
     *  http://localhost:5000/api/products?sortBy=price (sorting by Price)
     * 
     * 
     * 
     */


    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts([FromQuery] string sortBy)
        {
            var products = ProductData.GetProducts(sortBy);
            return Ok(products);
        }
    }
}
