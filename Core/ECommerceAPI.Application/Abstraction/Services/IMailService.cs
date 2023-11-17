using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstraction.Services
{
    public interface IMailService
    {
        Task SendMessageAsync(string to, string subject, string body, bool IsBodyHtml = true);
        Task SendMessageAsync(string[] tos, string subject, string body, bool IsBodyHtml = true);
    }
}
