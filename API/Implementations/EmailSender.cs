using API.Interfaces;
using API.Models;
using API.ViewModels;
using Microsoft.Extensions.Options;
using MimeKit;

namespace API.Implementations {

    public class EmailSender : IEmailSender {

        private readonly EmailSettings settings;

        public EmailSender(IOptions<EmailSettings> settings) {
            this.settings = settings.Value;
        }

        public SendEmailResponse SendEmail(ReservationVM reservation) {

            var message = new MimeMessage();
            var htmlContent = "";

            htmlContent += "<p>Dear guests,</p>";
            htmlContent += "<p style='font-size: 2.5rem'>Your RefNo is " + reservation.RefNo + "</p>";
            htmlContent += "<p></p>";
            htmlContent += "<p>We wish you a happy trip!</p>";

            message.From.Add(new MailboxAddress(settings.From, settings.UserName));
            message.To.Add(new MailboxAddress("Guest", reservation.Email));
            message.Subject = "Your Reservation Details";
            message.Body = new TextPart("html") {
                Text = htmlContent
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient()) {
                client.Connect(settings.SmtpClient, settings.Port, false);
                client.Authenticate(settings.UserName, settings.Password);
                client.Send(message);
                client.Disconnect(true);
            }

            return new SendEmailResponse();

        }

    }

}