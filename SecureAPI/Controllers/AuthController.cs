using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Accessible by any authenticated user
        [Authorize]
        [HttpGet("public")]
        public IActionResult PublicEndpoint()
        {
            return Ok("This is a public endpoint for authenticated users.");
        }

        // Accessible only by users with Admin role
        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminEndpoint()
        {
            return Ok("This is an Admin-only endpoint.");
        }

        // Accessible only by users who meet the AtLeast18 policy (have Age claim of 18)
        [Authorize(Policy = "AtLeast18")]
        [HttpGet("age-restricted")]
        public IActionResult AgeRestrictedEndpoint()
        {
            return Ok("You are at least 18 years old.");
        }

        // Accessible only by users with Admin role and AtLeast18 policy
        [Authorize(Roles = "Admin", Policy = "AtLeast18")]
        [HttpGet("admin-age-restricted")]
        public IActionResult AdminAndAgeRestrictedEndpoint()
        {
            return Ok("You are an Admin and at least 18 years old.");
        }
    }
}
