namespace login.Dtos.Security
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public TokenDto Token { get; set; }
        public IList Permits { get; set; }

        public int AgId { get; set; }
    }
}
