using DemoPractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoPractice.Controllers
{

    /*
     * Step 5: Running the Application
      Run the application. You can use tools like Postman or your browser to test the API endpoint.

       Endpoint: GET /api/items
       Query Parameters:
       PageNumber: The page number to retrieve (default is 1).
       PageSize: The number of items per page (default is 10).
       Example Requests:
       GET /api/items: Fetches the first 10 items.
       GET /api/items?PageNumber=2: Fetches the second page with 10 items.
       GET /api/items?PageNumber=3&PageSize=20: Fetches the third page with 20 items per page.
     * 
     * 
     */

















    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly List<Item> _items;

        public ItemsController()
        {
            // Sample data
            _items = new List<Item>();
            for (int i = 1; i <= 100; i++)
            {
                _items.Add(new Item { Id = i, Name = $"Item {i}" });
            }
        }

        [HttpGet]
        public ActionResult<PaginatedResponse<Item>> GetItems([FromQuery] PaginationParams paginationParams)
        {
            var totalItems = _items.Count;
            var totalPages = (int)Math.Ceiling(totalItems / (double)paginationParams.PageSize);

            var items = _items
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToList();

            var response = new PaginatedResponse<Item>
            {
                Data = items,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize,
                TotalPages = totalPages,
                TotalItems = totalItems
            };

            return Ok(response);
        }
    }
}
