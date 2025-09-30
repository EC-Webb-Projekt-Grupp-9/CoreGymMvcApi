using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Service.Dtos;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services;

public class AccountService(UserManager<UserEntity> userManager) : IAccountService
{
    private readonly UserManager<UserEntity> _userManager = userManager;


    public async Task<bool> Register(UserRegisterDto dto)
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
}
