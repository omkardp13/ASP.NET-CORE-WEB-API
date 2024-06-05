using DemoPractice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{

    /*
     * Get all products:

bash
Copy code
GET http://localhost:5000/api/products
Filter by name:

bash
Copy code
GET http://localhost:5000/api/products?name=Apple
Filter by category:

bash
Copy code
GET http://localhost:5000/api/products?category=Fruit
Filter by price range:

bash
Copy code
GET http://localhost:5000/api/products?minPrice=0.5&maxPrice=1.5
     * 
     */

















    private static List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "Apple", Price = 1.00m, Category = "Fruit" },
        new Product { Id = 2, Name = "Banana", Price = 0.50m, Category = "Fruit" },
        new Product { Id = 3, Name = "Carrot", Price = 0.30m, Category = "Vegetable" },
        new Product { Id = 4, Name = "Bread", Price = 2.00m, Category = "Bakery" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts(
        [FromQuery] string name,
        [FromQuery] string category,
        [FromQuery] decimal? minPrice,
        [FromQuery] decimal? maxPrice)
    {
        var query = Products.AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(p => p.Name.Contains(name));
        }

        if (!string.IsNullOrEmpty(category))
        {
            query = query.Where(p => p.Category == category);
        }

        if (minPrice.HasValue)
        {
            query = query.Where(p => p.Price >= minPrice.Value);
        }

        if (maxPrice.HasValue)
        {
            query = query.Where(p => p.Price <= maxPrice.Value);
        }

        return Ok(query.ToList());
    }
}
