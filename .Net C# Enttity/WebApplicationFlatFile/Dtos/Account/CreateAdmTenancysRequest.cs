using AccountControl.Resx;
using System.ComponentModel.DataAnnotations;

namespace AccountControll.Dtos.Account
{
    public class CreateAdmTenancysRequest
    {
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string Name { get; set; }
        [Required(ErrorMessage = SecurityMsg.RequiredDefault)]
        public string SudDominio { get; set; }
    }
}
