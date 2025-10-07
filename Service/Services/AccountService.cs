using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Service.Dtos;
using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services;

public class AccountService(UserManager<UserEntity> userManager) : IAccountService
{
    private readonly UserManager<UserEntity> _userManager = userManager;


    public async Task<bool> RegisterAsync(UserRegisterDto dto)
    {
        var entity = new UserEntity
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            UserName = dto.Email
        };

        var result = await _userManager.CreateAsync(entity, dto.Password);
        return result.Succeeded;
    }

    public async Task<User> GetUserAsync(string email)
    {
        var Entity = await _userManager.FindByEmailAsync(email);
        if (Entity is null) return null!;

        var model = new User
        {
            FirstName = Entity.FirstName,
            LastName= Entity.LastName,
            Email = Entity.Email,
        };

        return model;
    }

    public async Task<bool> UpdatePasswordAsync(UpdatePasswordDto dto)
    {
        var entity = await _userManager.FindByEmailAsync(dto.Email);
        if (entity == null) return false;

        var currentPasswordIsValid = await _userManager.CheckPasswordAsync(entity, dto.CurrentPassword);
        if (!currentPasswordIsValid) return false;

        var result = await _userManager.ChangePasswordAsync(entity, dto.CurrentPassword, dto.NewPassword);
        return result.Succeeded ? true : false;
    }

    public async Task<bool> UpdateAccountInformationAsync(UpdateAccountInformationDto dto)
    {
        var entity = await _userManager.FindByEmailAsync(dto.CurrentEmail);
        if (entity == null || await _userManager.CheckPasswordAsync(entity, dto.Password) == false) return false;

        var emailResult = await _userManager.SetEmailAsync(entity, dto.NewEmail);
        var userNameResult = await _userManager.SetUserNameAsync(entity, dto.NewEmail);

        if (!emailResult.Succeeded || !userNameResult.Succeeded) return false;

        var updateResult = await _userManager.UpdateAsync(entity);

        return updateResult.Succeeded ? true : false;
    }
}
