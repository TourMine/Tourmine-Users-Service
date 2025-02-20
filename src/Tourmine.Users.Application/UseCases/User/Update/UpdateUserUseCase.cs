using MediatR;
using Tourmine.Users.Application.Commands.Update;
using Tourmine.Users.Application.Interfaces;
using Tourmine.Users.Application.Requests;

namespace Tourmine.Users.Application.UseCases.User.Update
{
    public class UpdateUserUseCase : BaseUseCase, IUpdateUserUseCase
    {
        public UpdateUserUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Execute(Guid id, UpdateUserRequest request)
        {
            return await mediator.Send(new UpdateUserCommand(id, request));
        }
    }
}
