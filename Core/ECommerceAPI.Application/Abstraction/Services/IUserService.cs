using ECommerceAPI.Application.DTOS.User;
using ECommerceAPI.Application.Features.Commands.AppUser.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstraction.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
    }
}
