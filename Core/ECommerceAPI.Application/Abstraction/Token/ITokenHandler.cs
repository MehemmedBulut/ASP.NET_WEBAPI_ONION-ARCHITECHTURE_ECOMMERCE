using ECommerceAPI.Application.DTOS;
using ECommerceAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstraction.Token
{
    public interface ITokenHandler
    {
        DTOS.Token CreateAccessToken(int second, AppUser appUser);
        string CreateRefreshToken();
    }
}
