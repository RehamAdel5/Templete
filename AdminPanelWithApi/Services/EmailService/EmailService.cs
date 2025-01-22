using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;
using AdminPanelWithApi.Services.EmailService.Models;

namespace AdminPanelWithApi.Services.EmailService
{
    public class EmailService : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var emailConfig = _configuration.GetSection("EmailConfiguration").Get<EmailConfigurationModel>();
                MailMessage mail = new MailMessage(emailConfig?.From ?? "", email);
                mail.Subject = subject;
                mail.Body = htmlMessage;
                mail.IsBodyHtml = true;
                SmtpClient client = new SmtpClient
                {
                    Port = emailConfig.Port,
                    Host = emailConfig.SmtpServer,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(emailConfig.UserName, emailConfig.Password),
                };

           
                // Send the email
                client.SendAsync(mail, null);
            }
            catch (Exception)
            {
            }

        }
    }
}
