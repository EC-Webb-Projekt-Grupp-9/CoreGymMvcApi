using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces;

public interface IAuthService
{
    Task<bool> SignInAsync(UserLoginDto dto);
    Task<bool> SignOut();
}
