using AccountControl.Dtos.Email;

namespace AccountControl.Services.Email
{
    public interface IEmailService
    {
        Task SendAsync(EmailMessage emailMessage, bool isHtml, IFormFile file, string fileLocation, CancellationToken ct);
        Task SendRportAsync(EmailMessage emailMessage, bool isHtml, IFormFile file, string fileLocation, CancellationToken ct);
    }
}
