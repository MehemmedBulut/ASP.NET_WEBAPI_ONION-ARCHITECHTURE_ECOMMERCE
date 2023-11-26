using MediatR;

namespace ECommerceAPI.Application.Features.Queries.AppUser.GetRolesToUsers
{
    public class GetRolesToUsersQueryRequest:IRequest<GetRolesToUsersQueryResponse>
    {
        public string UserId { get; set; }
    }
}