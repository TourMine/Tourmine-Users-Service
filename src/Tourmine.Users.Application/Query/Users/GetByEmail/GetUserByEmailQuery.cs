using MediatR;
using Tourmine.Users.Application.Responses;

namespace Tourmine.Users.Application.Query.Users.GetByEmail
{
    public class GetUserByEmailQuery : IRequest<UserResponse>
    {
        public string Email { get; set; }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
