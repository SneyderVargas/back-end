using AccountControl.Resx;
using System.ComponentModel.DataAnnotations;

namespace AccountControll.Dtos.Account
{
    public class AdmTenancysDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SudDominio { get; set; }
    }
}
