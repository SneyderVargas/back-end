using login.Resx;
using System.ComponentModel.DataAnnotations;

namespace login.Dtos.Security
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = SecurityMsg.UserNameRequiredValidation)]
        [StringLength(50, ErrorMessage = SecurityMsg.UserNameLengthValidation, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required(ErrorMessage = SecurityMsg.PasswordRequiredValidation)]
        [StringLength(30, ErrorMessage = SecurityMsg.PasswordLengthValidation, MinimumLength = 5)]
        public string Password { get; set; }
    }
}
