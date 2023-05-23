namespace login.Infrastructure.Models
{
    public class PermissionCodes
    {
        public PermissionCodes (string Code)
        {
            this.Code = Code;
        }
        public string Code { get; set; }
    }
}
