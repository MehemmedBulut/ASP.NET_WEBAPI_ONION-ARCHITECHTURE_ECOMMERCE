using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstraction.Services
{
    public interface IMailService
    {
        Task SendMailAsync(string to, string subject, string body, bool IsBodyHtml = true);
        Task SendMailAsync(string[] tos, string subject, string body, bool IsBodyHtml = true);
        Task SendePasswordResetMailAsync(string to, string userId, string resetToken);
    }
}
