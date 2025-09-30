using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;
using System.Security.Claims;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("signin")]
    public async Task<IActionResult> SignInAsync(UserLoginDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _authService.SignInAsync(dto);
        return result ? Ok(result) : BadRequest(ModelState);
    }

    [Authorize]
    [HttpGet("pingauth")]
    public async Task<IActionResult> PingAuth()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);

        if (string.IsNullOrEmpty(email))
            return Unauthorized(new { Message = "Email claim not found" });

        return Ok(new { Email = email });
    }
}
