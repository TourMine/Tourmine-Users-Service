using MediatR;
using Tourmine.Users.Application.Requests;

namespace Tourmine.Users.Application.Commands
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public UserRequest Request { get; set; }

        public RegisterUserCommand(UserRequest request)
        {
            Request = request;
        }
    }
}
