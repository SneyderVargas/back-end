using login.Resx;
using System.ComponentModel.DataAnnotations;

namespace login.Dtos.Security
{
    public class LogoutRequestDto
    {
        [Required(ErrorMessage = SecurityMsg.UserNameRequiredValidation)]
        [StringLength(50, ErrorMessage = SecurityMsg.UserNameLengthValidation, MinimumLength = 3)]
        public string UserName { get; set; }
    }
}
