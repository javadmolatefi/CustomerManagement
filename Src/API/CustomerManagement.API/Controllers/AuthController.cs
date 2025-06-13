using CustomerManagement.Application.Common.Identity;
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
    public async Task<IActionResult> Register(string email, string password)
    {
        var token = await _identity.RegisterAsync(email, password);
        return token == null ? BadRequest("Registration failed") : Ok(token);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var token = await _identity.LoginAsync(email, password);
        return token == null ? Unauthorized() : Ok(token);
    }
}
