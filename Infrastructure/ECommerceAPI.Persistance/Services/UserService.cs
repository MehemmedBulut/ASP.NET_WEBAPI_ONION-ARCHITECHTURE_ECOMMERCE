using ECommerceAPI.Application.Abstraction.Services;
using ECommerceAPI.Application.DTOS.User;
using ECommerceAPI.Application.Features.Commands.AppUser.CreateUser;
using ECommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistance.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public UserService(UserManager<AppUser> manager)
        {
            _userManager = manager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Email = model.Email,
                NameSurname = model.NameSurname,
            }, model.Password);

            CreateUserResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Istifadəçi qeydiyyatı uğurla yerinə yetirildi";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }

    }
}
