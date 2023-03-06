namespace AccountControll.Services.Security
{
    public interface ITenancysServices
    {
        Task<(bool Succeeded, string Message)> Get();
        Task<(bool Succeeded, string Message)> GetAll();
        Task<(bool Succeeded, string Message)> Create();
        Task<(bool Succeeded, string Message)> Update();
        Task<(bool Succeeded, string Message)> Delete();
    }
}
