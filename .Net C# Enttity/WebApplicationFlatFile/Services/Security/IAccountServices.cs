using AccountControll.Data.Entities;
using AccountControll.Dtos.Account;

namespace AccountControll.Services.Security
{
    public interface IAccountServices
    {
        Task<(bool Succeeded, string Message, List<AdmUsersEntity> Users)> GetAllAdmUsers();
        Task<(bool Success, string Message)> CreateAdmUser(AdmUsersEntity User);
    }
}
