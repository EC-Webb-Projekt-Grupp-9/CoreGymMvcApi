using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;
using System.Security.Claims;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService, IAccountService accountService) : ControllerBase
{
    private readonly IAuthService _authService = authService;
    private readonly IAccountService _accountService = accountService;

    [HttpPost("signin")]
    public async Task<IActionResult> SignInAsync(UserLoginDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _authService.SignInAsync(dto);
        return result ? Ok(new {Success = true}) : BadRequest(ModelState);
    }

    [Authorize]
    [HttpGet("signout")]
    public async Task<IActionResult> SignOut()
    {
        bool result = await _authService.SignOut();
        return Ok();
    }

    [Authorize]
    [HttpGet("pingauth")]
    public async Task<IActionResult> PingAuth()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);

        if (string.IsNullOrEmpty(email))
            return Unauthorized(new { Message = "Email claim not found" });

        var user = _accountService.GetUserAsync(email);

        return Ok(user);
    }
}
