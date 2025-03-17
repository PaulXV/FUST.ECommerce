using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace FUST.E_Commerce.Services;
public class EmailService : IEmailSender
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Your Company", "andrea.monico.24@itsaltoadriatico.it"));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = subject;

        message.Body = new TextPart("html")
        {
            Text = body
        };

        using (var client = new SmtpClient())
        {
            var email = _configuration["Email"];
            var password = _configuration["Password"];

            await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(email, password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
