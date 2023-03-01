using AccountControl.Data.Entities;
using AccountControl.Dtos.Security;

namespace AccountControl.Services.Security
{
    public interface IJwtGenerator
    {
        TokenDto CreateToken(UserEntity user, List<string> roles);
        TokenDto GenerateToken(string userId, string userName);
    }
}
