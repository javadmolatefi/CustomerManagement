using CustomerManagement.Application.Common.Identity;
using CustomerManagement.Application.Common.Models;
using CustomerManagement.Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IIdentityService _identity;

    public AuthController(IIdentityService identity)
    {
        _identity = identity;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] AuthRequest request)
    {
        var token = await _identity.RegisterAsync(request.Email, request.Password);
        return token == null ? BadRequest("Registration failed") : Ok(token);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthRequest request)
    {
        var token = await _identity.LoginAsync(request.Email, request.Password);
        return token == null ? Unauthorized() : Ok(token);
    }
}
