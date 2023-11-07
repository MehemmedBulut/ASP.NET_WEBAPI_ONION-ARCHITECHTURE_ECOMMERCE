using ECommerceAPI.Application.Abstraction.Services;
using ECommerceAPI.Application.DTOS.User;
using ECommerceAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse response = await _userService.CreateAsync(new()
            {
                Email = request.Email,
                NameSurname = request.NameSurname,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                UserName = request.UserName,
            });

            return new()
            {
                    Message = response.Message,
                    Succeeded= response.Succeeded,
            };
        }
    }
}
