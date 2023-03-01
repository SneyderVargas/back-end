using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using AccountControl.Dtos.Email;

namespace AccountControl.Services.Email
{
    public class MailkitEmailService : IEmailService
    {
        public readonly EmailConfiguration _emailConfiguration;
        public MailkitEmailService(IOptions<EmailConfiguration> emailConfigurationOptions)
        {
            _emailConfiguration = emailConfigurationOptions.Value;
        }
        public async Task SendAsync(EmailMessage emailMessage, bool isHtml, IFormFile file, string fileLocation, CancellationToken ct)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.toAddress.Select(x => new MailboxAddress("name", x.address)));
            message.From.AddRange(emailMessage.fromAdress.Select(x => new MailboxAddress("name", x.address)));

            message.Subject = emailMessage.subject;
            var builder = new BodyBuilder();
            if (isHtml)
            {
                builder.HtmlBody = emailMessage.content;
            }
            else
            {
                builder.TextBody = emailMessage.content;
            }
            if (file != null)
            {
                builder.Attachments.Add(file.FileName, file.OpenReadStream());
            }

            if (fileLocation != "")
            {
                builder.Attachments.Add(@"C:\Downloads\" + fileLocation + ".docx");
            }
            //builder.Attachments.Add(@"C:\Users\jsalasma\Downloads\TestReport.pdf");


            message.Body = builder.ToMessageBody();
            using (var emailClient = new SmtpClient())
            {
                try
                {
                    //The last parameter here is to use SSL (Which you should!)
                    emailClient.Connect(_emailConfiguration.smtpServer, _emailConfiguration.smtpPort, false);
                    //Remove any OAuth functionality as we won't be using it. 
                    emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                    emailClient.Authenticate(_emailConfiguration.stmpUserName, _emailConfiguration.smtpPassword);
                    await emailClient.SendAsync(message, ct);
                    await emailClient.DisconnectAsync(true, ct);

                }
                catch (Exception e)
                {
                    var gf = e;
                    return;
                }
            }
        }

        public async Task SendRportAsync(EmailMessage emailMessage, bool isHtml, IFormFile file, string fileLocation, CancellationToken ct)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.toAddress.Select(x => new MailboxAddress("name", x.address)));
            message.From.AddRange(emailMessage.fromAdress.Select(x => new MailboxAddress("name", x.address)));

            message.Subject = emailMessage.subject;
            var builder = new BodyBuilder();
            if (isHtml)
            {
                builder.HtmlBody = emailMessage.content;
            }
            else
            {
                builder.TextBody = emailMessage.content;
            }
            if (file != null)
            {
                builder.Attachments.Add(file.FileName, file.OpenReadStream());
            }

            if (fileLocation != "")
            {
                builder.Attachments.Add(@"C:\Downloads\" + fileLocation + ".xlsx");
            }

            message.Body = builder.ToMessageBody();
            using (var emailClient = new SmtpClient())
            {
                try
                {
                    //The last parameter here is to use SSL (Which you should!)
                    emailClient.Connect(_emailConfiguration.smtpServer, _emailConfiguration.smtpPort, false);
                    //Remove any OAuth functionality as we won't be using it. 
                    emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                    emailClient.Authenticate(_emailConfiguration.stmpUserName, _emailConfiguration.smtpPassword);
                    await emailClient.SendAsync(message, ct);
                    await emailClient.DisconnectAsync(true, ct);
                }
                catch (Exception e)
                {
                    var gf = e;
                    return;
                }
            }
        }
    }
}
