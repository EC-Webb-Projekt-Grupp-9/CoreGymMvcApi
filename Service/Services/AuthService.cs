using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Service.Dtos;
using Service.Interfaces;

namespace Service.Services;

public class AuthService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : IAuthService
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    public async Task<bool> SignInAsync(UserLoginDto dto)
    {
        var entity = await _userManager.FindByEmailAsync(dto.Email);
        if (entity == null) return false;

        var result = await _signInManager.PasswordSignInAsync(entity, dto.Password, true, false);
        return result.Succeeded ? true : false;
    }
}
