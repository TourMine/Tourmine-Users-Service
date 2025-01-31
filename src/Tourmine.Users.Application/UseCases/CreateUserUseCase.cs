using MediatR;
using Tourmine.Users.Application.Commands;
using Tourmine.Users.Application.Interfaces;
using Tourmine.Users.Application.Requests;

namespace Tourmine.Users.Application.UseCases
{
    public class CreateUserUseCase : BaseUseCase, ICreateUserUseCase
    {
        public CreateUserUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Execute(UserRequest request)
        {
            return await mediator.Send(new CreateUserCommand(request));
        }
    }
}
