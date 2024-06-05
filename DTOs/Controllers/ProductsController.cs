using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeConcepts.DTOs;
using PracticeConcepts.Models;

namespace PracticeConcepts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private static readonly List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Product1", Price = 10.0M },
            new Product { Id = 2, Name = "Product2", Price = 20.0M }
        };

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            var productDTOs = Products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return Ok(productDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var productDTO = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name
            };

            return Ok(productDTO);
        }

        [HttpPost]
        public ActionResult<ProductDTO> CreateProduct(ProductDTO productDTO)
        {
            var newProduct = new Product
            {
                Id = Products.Max(p => p.Id) + 1,
                Name = productDTO.Name,
                Price = 0 // Default price, since it's not in DTO
            };

            Products.Add(newProduct);

            productDTO.Id = newProduct.Id;

            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, productDTO);
        }
    }
}
