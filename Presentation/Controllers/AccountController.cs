using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;
using Service.Models;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(IAccountService accountService) : ControllerBase
{
    private readonly IAccountService _accountService = accountService;

    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterDto dto)
    {
        
        if (!ModelState.IsValid) return BadRequest();

        var result = await _accountService.Register(dto);
        return result ? Ok() : Problem("Could not create user");
    }

    [HttpPost("updatepassword")]
    public async Task<IActionResult> UpdatePassword(UpdatePasswordDto dto)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _accountService.UpdatePassword(dto);
        return result ? Ok() : Problem("could not update password");
    }
}
