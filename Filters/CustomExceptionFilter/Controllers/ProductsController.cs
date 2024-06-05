// Controllers/ProductsController.cs
using Microsoft.AspNetCore.Mvc;
using PracticeConcepts.Models;
using PracticeConcepts.Services;
using System.Collections.Generic;

namespace CustomExceptionFilterExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            _productRepository.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productRepository.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productRepository.Delete(id);
            return NoContent();
        }
    }
}
