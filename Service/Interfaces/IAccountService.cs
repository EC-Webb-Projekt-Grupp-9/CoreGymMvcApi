using Service.Dtos;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces;

public interface IAccountService
{
    Task<User> GetUserAsync(string email);
    Task<bool> RegisterAsync(UserRegisterDto dto);
    Task<bool> UpdateAccountInformationAsync(UpdateAccountInformationDto dto);
    Task<bool> UpdatePasswordAsync(UpdatePasswordDto dto);
}
