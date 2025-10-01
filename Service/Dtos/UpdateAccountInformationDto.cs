using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos;

public class UpdateAccountInformationDto
{
    [MaxLength(150)]
    [Required]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email need to be formatted as <name@domain.com>")]
    public string CurrentEmail { get; set; } = null!;

    [MaxLength(150)]
    [Required]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email need to be formatted as <name@domain.com>")]
    public string NewEmail { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a Password")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$",
       ErrorMessage = "Password Requirements: \nMinimum 8 characters. \nAt least one uppercase letter. \nAt least one digit. \nAt least one special character")]
    public string Password { get; set; } = null!;
}
