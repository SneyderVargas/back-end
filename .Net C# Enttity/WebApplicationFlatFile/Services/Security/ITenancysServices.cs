using AccountControll.Data.Entities;
using AccountControll.Dtos;

namespace AccountControll.Services.Security
{
    public interface ITenancysServices
    {
        Task<(bool Succeeded, string Message)> Create(AdmTenancysEntity Tenancys);
        Task<(bool Succeeded, string Message, Response<List<AdmTenancysEntity>> response)> GetAll(PaginationFilter filter);
    }
}
