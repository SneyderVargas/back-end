using WebApplicationFlatFile.Data.Entities;
using WebApplicationFlatFile.Dtos.Security;

namespace WebApplicationFlatFile.Services.Security
{
    public interface IJwtGenerator
    {
        TokenDto CreateToken(UserEntity user, List<string> roles);
        TokenDto GenerateToken(string userId, string userName);
    }
}
