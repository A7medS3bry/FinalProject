using System;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using UserMangmentService.Models;

namespace UserMangmentService.Service
{
    public class EmailServices : IEmailServices
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailServices(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig ?? throw new ArgumentNullException(nameof(emailConfig));
        }

        public void SendEmail(Message messag)
        {
            var emailMessage = CreateEmailMessage(messag);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            //var emailMessage = new MimeMessage();
            //emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
            //emailMessage.To.AddRange(message.To);
            //emailMessage.Subject = message.Subject;
            //emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            //return emailMessage;
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("TaskAsync", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = $"<p>Please, Click in Link <p><p>{message.Content}</p><p>Thank you!</p>";

            emailMessage.Body = builder.ToMessageBody();

            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();

            try
            {
                client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.StartTls);
                client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw;
            }
            finally
            {
                if (client.IsConnected)
                {
                    client.Disconnect(true);
                }
            }
        }

    }
}
