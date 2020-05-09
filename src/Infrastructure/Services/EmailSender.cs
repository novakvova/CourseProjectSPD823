using MailKit.Net.Smtp;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using MimeKit;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Infrastructure.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Адміністрація", "pady@ukr.net"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.ukr.net", 465, true);
                await client.AuthenticateAsync("pady@ukr.net", "JG8nbBbU248dtR9l");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
        //public Task SendEmailAsync(string email, string subject, string message)
        //{
        //    // TODO: Wire this up to actual email sending logic via SendGrid, local SMTP, etc.
        //    return Task.CompletedTask;
        //}
    }
}
