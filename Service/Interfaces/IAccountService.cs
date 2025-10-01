using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces;

public interface IAccountService
{
    Task<bool> RegisterAsync(UserRegisterDto dto);
    Task<bool> UpdateAccountInformationAsync(UpdateAccountInformationDto dto);
    Task<bool> UpdatePasswordAsync(UpdatePasswordDto dto);
}
