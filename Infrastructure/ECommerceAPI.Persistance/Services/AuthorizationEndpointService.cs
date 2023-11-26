using ECommerceAPI.Application.Abstraction.Services;
using ECommerceAPI.Application.Abstraction.Services.Configurations;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistance.Services
{
    public class AuthorizationEndpointService : IAuthorizationEndpointService
    {
        readonly IApplicationService _applicationService;
        readonly IEndpointReadRepository _endpointReadRepository;
        readonly IEndpointWriteRepository _endpointWriteRepository;
        readonly IMenuReadRepository _menuReadRepository;
        readonly IMenuWriteRepository _menuWriteRepository;
        readonly RoleManager<AppRole> _roleManager;

        public AuthorizationEndpointService(IApplicationService applicationService, IEndpointWriteRepository endpointWriteRepository, IEndpointReadRepository endpointReadRepository, IMenuReadRepository menuReadRepository, IMenuWriteRepository menuWriteRepository, RoleManager<AppRole> roleManager)
        {
            _applicationService = applicationService;
            _endpointWriteRepository = endpointWriteRepository;
            _endpointReadRepository = endpointReadRepository;
            _menuReadRepository = menuReadRepository;
            _menuWriteRepository = menuWriteRepository;
            _roleManager = roleManager;
        }

        public async Task AssignRoleEndpoints(string[] roles, string menu, string code, Type type)
        {
            Menu _menu = await _menuReadRepository.GetSingleAsync(m => m.Name == menu);
            if (_menu == null)
            {
                _menu = new()
                {
                    Id = Guid.NewGuid(),
                    Name = menu
                };
                await _menuWriteRepository.AddAsync(_menu);
                await _endpointWriteRepository.SaveAsync();
            }
            

            Endpoint? endPoint =  await _endpointReadRepository.Table.Include(e=>e.Menu).Include(e=>e.Roles).FirstOrDefaultAsync(e=>e.Code== code && e.Menu.Name == menu);

            if(endPoint == null) 
            {
                var action = _applicationService.GetAuthorizeDefinitionEndpoints(type).FirstOrDefault(m => m.Name == menu)?
                    .Actions.FirstOrDefault(e => e.Code == code);

                endPoint = new()
                {
                    Code = action.Code,
                    ActionType = action.ActionType,
                    HttpType = action.HttpType,
                    Definition = action.Definition,
                    Id = Guid.NewGuid(),
                    Menu = _menu,
                };

                await _endpointWriteRepository.AddAsync(endPoint);
                await _endpointWriteRepository.SaveAsync();
            }

            foreach (var role in endPoint.Roles)
                endPoint.Roles.Remove(role);

            var appRoles = await _roleManager.Roles.Where(r => roles.Contains(r.Name)).ToListAsync();

            foreach (var role in appRoles)
                endPoint.Roles.Add(role);

            await _endpointWriteRepository.SaveAsync();

        }

        public async Task<List<string>> GetRolesToEndpointAsync(string code, string menu)
        {
            Endpoint? endpoint = await _endpointReadRepository.Table
                .Include(e=>e.Roles)
                .Include(e => e.Menu)
                .FirstOrDefaultAsync(e=>e.Code == code && e.Menu.Name == menu);
            if(endpoint != null)
                return endpoint.Roles.Select(r => r.Name).ToList();
            return null;
        }
    }
}
