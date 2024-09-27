using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    [HttpPost("generate-token")]
    public IActionResult GenerateToken([FromBody] TokenRequest request)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, request.Username),
            new Claim(ClaimTypes.Role, request.Role), // Add role claim
            new Claim("Age", request.Age.ToString())  // Add Age claim
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("rukbgjdyhgvfjhbfjkfuhuhkdfrdu,bjgubfvhjgyfhbmjjyghijngnhult,gtuk,kgungjhbguk.fngbcfkb"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "your_issuer",
            audience: "your_audience",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}

public class TokenRequest
{
    public string Username { get; set; }
    public string Role { get; set; }
    public int Age { get; set; }
}
