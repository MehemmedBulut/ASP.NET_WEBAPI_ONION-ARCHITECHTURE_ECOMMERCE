using ECommerceAPI.Application.Abstraction.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure.Services
{
    public class MailService : IMailService
    {
        readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool IsBodyHtml = true)
        {
            await SendMailAsync(new[] {to}, subject, body, IsBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool IsBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = IsBodyHtml;
            foreach(var to in tos)
                mail.To.Add(to);

            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(_configuration["Mail:Username"], _configuration["Mail:Password"], System.Text.Encoding.UTF8);

            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = _configuration["Mail:Host"];
            smtp.SendMailAsync(mail);
        }
        public async Task SendePasswordResetMailAsync(string to, string userId, string resetToken)
        {
            StringBuilder mail = new();
            mail.AppendLine("Salam<br> Əgər yeni şifrə tələb ettinizsə aşağıdakı linkdən şifrənizi yeniləyə bilərsiniz!<br>" +
                "<strong><a target=\"_blank\" href=\"");
            mail.AppendLine(_configuration["ReactClientUrl"]);
            mail.AppendLine("update-password");
            mail.AppendLine(userId);
            mail.AppendLine("/");
            mail.AppendLine("\">Yeni şifrə tələbi üçün klikləyin...</a></strong><br><br><span style=font-size:12px;\">Not:Əgər bu tələb sizin tərəfindən gerçəkləşdirilməyibsə bu maili ciddiyə almayın</span>");

            await SendMailAsync(to, "Şifrə yeniləmə tələbi", mail.ToString());
        }
    }
}
