using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities;

public class UserEntity : IdentityUser
{
    [MaxLength(50)]
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [MaxLength(50)]
    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    [MaxLength(20)]
    [ProtectedPersonalData]
    public override string? PhoneNumber { get; set; }

    [MaxLength(150)]
    [ProtectedPersonalData]
    public override string? Email { get; set; }

    [ProtectedPersonalData]
    public override string? UserName { get; set; }
}
