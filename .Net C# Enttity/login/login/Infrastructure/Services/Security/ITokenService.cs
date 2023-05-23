using login.Dtos.Security;

namespace login.Infrastructure.Services.Security
{
    public interface ITokenService
    {
        TokenDto GenerateToken(string userId, string userName);
        (bool IsValid, string UserId, string Message) IsValid(string token);
    }
}
