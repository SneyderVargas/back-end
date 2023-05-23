using login.Infrastructure.Models;

namespace login.Infrastructure.Services.Security
{
    public interface IAccountService
    {
        Task<(bool Success, string Message, User User, List<PermissionCodes> Permissions, int AdId)> Login (string UserName, string Password, CancellationToken ct);
    }
}
