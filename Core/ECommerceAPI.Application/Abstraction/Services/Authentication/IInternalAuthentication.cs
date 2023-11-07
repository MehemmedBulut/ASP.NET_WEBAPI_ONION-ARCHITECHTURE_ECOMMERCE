using ECommerceAPI.Application.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstraction.Services.Authentication
{
    public interface IInternalAuthentication
    {
        Task<DTOS.Token> LoginAsync(string userNameOrEmail, string password, int accessTokenLifeTime);
    }
}
