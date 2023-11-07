using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstraction.Services.Authentication
{
    public interface IExternalAuthentication
    {
        Task<DTOS.Token> FacebookLoginAsync(string authToken, int accesTokenLifeTime);
        Task<DTOS.Token> GoogleLoginAsync(string idToken, int accesTokenLifeTime);
    }
}
