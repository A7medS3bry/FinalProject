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
            //builder.HtmlBody = $"<div style=\"background-color: #f0f0f0; font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px; border-radius: 10px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\"><div style=\"background-color: #007bff; color: #ffffff; padding: 10px; text-align: center; border-top-left-radius: 10px; border-top-right-radius: 10px; font-size: 18px;\">Email From TaskAsync</div><div style=\"color: black; padding: 20px; font-size: 16px; text-align: center;\"><p><b>Thank You For Using TaskAsync.</b></p><p style=\"margin-top: 20px;\"><a href=\"{message.Content}\" style=\"background-color: #007bff; color: #fff; padding: 10px 20px; text-decoration: none; border-radius: 5px;\">Click Here</a></p></div></div>";
            builder.HtmlBody = $@"
                    <div style=""background-color: #f0f0f0; font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px; border-radius: 10px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);"">
                        <div style=""background-color: #007bff; color: #ffffff; padding: 10px; text-align: center; border-top-left-radius: 10px; border-top-right-radius: 10px; font-size: 18px;"">TaskAsync</div>
                        <div style=""color: black; padding: 20px; font-size: 16px;"">
                            <p>Hello,</p>
                            <p>Thanks for your interest in TaskAsync!</p>
                            <p style=""text-align: center;""><a href=""{message.Content}"" style=""background-color: #007bff; color: #fff; padding: 10px 20px; text-decoration: none; border-radius: 5px;"">click Here</a></p>
                            <p>We will notify you of our decision by email within 24 hours.</p>
                            <p>Thanks for your time,</p>
                            <p>The TaskAsync Team</p>
                        </div>
                    </div>";

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
