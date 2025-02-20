using MediatR;
using Tourmine.Users.Application.Requests;

namespace Tourmine.Users.Application.Commands.Update
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public UpdateUserRequest Request { get; set; }

        public UpdateUserCommand(Guid id, UpdateUserRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
