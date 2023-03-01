namespace AccountControll.Dtos.Account
{
    public class CreateAdmUserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string TypeUsers { get; set; }
        public string? Data { get; set; }
        public DateTime LastLogin { get; set; }
        public int Active { get; set; }
        public DateTime CreateRegisterDate { get; set; }
        public DateTime UpdateRegisterDate { get; set; }
        public int ActiveRegister { get; set; }
        public int Tenancys { get; set; }
        public string? Steps { get; set; }
    }
}
