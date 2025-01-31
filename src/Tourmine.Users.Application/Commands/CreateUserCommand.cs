using MediatR;
using Tourmine.Users.Application.Requests;

namespace Tourmine.Users.Application.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public UserRequest Request { get; set; }

        public CreateUserCommand(UserRequest request)
        {
            Request = request;
        }
    }
}
