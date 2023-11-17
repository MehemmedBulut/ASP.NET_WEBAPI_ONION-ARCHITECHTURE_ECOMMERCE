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

        public async Task SendMessageAsync(string to, string subject, string body, bool IsBodyHtml = true)
        {
            await SendMessageAsync(new[] {to}, subject, body, IsBodyHtml);
        }

        public async Task SendMessageAsync(string[] tos, string subject, string body, bool IsBodyHtml = true)
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
    }
}
