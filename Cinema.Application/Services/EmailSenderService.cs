using System.Net.Mail;
using System.Net;

namespace Cinema.Application.Services
{
    public class EmailSenderService
    {
        private readonly IUserContext _userContext;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public EmailSenderService(string smtpServer, int smtpPort, string smtpUsername,
            string smtpPassword, IUserContext userContext)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _smtpUsername = smtpUsername;
            _smtpPassword = smtpPassword;
            _userContext = userContext;
        }

        public async Task SendPaymentConfirmationEmail(string orderId, decimal amountPaid)
        {
            var currenUserEmail = _userContext.GetCurrentUser()!.Email;

            // Tworzenie treści wiadomości e-mail
            var message = new MailMessage();
            message.From = new MailAddress(_smtpUsername);
            message.To.Add(currenUserEmail);
            message.Subject = "Potwierdzenie płatności";
            message.Body = $"Dokonano płatności dla zamówienia o identyfikatorze {orderId}. Zapłacono kwotę {amountPaid} PLN.";

            // Konfiguracja klienta SMTP
            using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                smtpClient.EnableSsl = true;

                // Wysłanie wiadomości e-mail
                await smtpClient.SendMailAsync(message);
            }
        }
    }
}
