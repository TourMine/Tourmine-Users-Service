using MediatR;
using Tourmine.Users.Application.Requests;

namespace Tourmine.Users.Application.Commands.Register
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public RegisterRequest Request { get; set; }

        public RegisterUserCommand(RegisterRequest request)
        {
            Request = request;
        }
    }
}
