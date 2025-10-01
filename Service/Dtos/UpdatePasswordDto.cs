using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos;

public class UpdatePasswordDto
{
    [MaxLength(150)]
    [Required]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email need to be formatted as <name@domain.com>")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a Password")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$",
      ErrorMessage = "Password Requirements: \nMinimum 8 characters. \nAt least one uppercase letter. \nAt least one digit. \nAt least one special character")]
    public string CurrentPassword { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a Password")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$",
      ErrorMessage = "Password Requirements: \nMinimum 8 characters. \nAt least one uppercase letter. \nAt least one digit. \nAt least one special character")]
    public string NewPassword { get; set; } = null!;

    [Required(ErrorMessage = "You must confirm your Password")]
    [DataType(DataType.Password)]
    [Compare(nameof(NewPassword), ErrorMessage = "Your Password do not match!")]
    public string ConfirmNewPassword { get; set; } = null!;
}
