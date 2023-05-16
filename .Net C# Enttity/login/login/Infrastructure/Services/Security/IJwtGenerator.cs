using login.Data.Entities;
using login.Dtos.Security;

namespace login.Infrastructure.Services.Security
{
    public interface IJwtGenerator
    {
        TokenDto CrearToken(UserEntity usuario, List<string> roles);
        TokenDto GenerateToken(string userId, string userName);
    }
}
