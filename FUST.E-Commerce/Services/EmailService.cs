using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace FUST.E_Commerce.Services
{
    public class EmailService
    {
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
                await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("andrea.monico.24@stud.itsaltoadriatico.it", "zacwuqbtufmkoijd");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
