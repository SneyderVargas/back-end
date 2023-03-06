using AccountControl.Resx;
using System.ComponentModel.DataAnnotations;

namespace AccountControll.Dtos.Account
{
    public class CreateAdmUserRequest
    {
        [Required(ErrorMessage = SecurityMsg.UserNameRequiredValidation)]
        public string Email { get; set; }
        [Required(ErrorMessage = SecurityMsg.UserNameRequiredValidation)]
        public string Name { get; set; }
        [Required(ErrorMessage = SecurityMsg.UserNameRequiredValidation)]
        public string Password { get; set; }
        [Required(ErrorMessage = SecurityMsg.UserNameRequiredValidation)]
        public int Tenancys { get; set; }
    }
}
