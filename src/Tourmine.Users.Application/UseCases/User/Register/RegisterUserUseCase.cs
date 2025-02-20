using MediatR;
using Tourmine.Users.Application.Commands;
using Tourmine.Users.Application.Commands.Register;
using Tourmine.Users.Application.Interfaces;
using Tourmine.Users.Application.Query.Users.GetByEmail;
using Tourmine.Users.Application.Requests;

namespace Tourmine.Users.Application.UseCases.User.Create
{
    public class RegisterUserUseCase : BaseUseCase, IRegisterUserUseCase
    {
        public RegisterUserUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Execute(RegisterRequest request)
        {
            var userExists = await mediator.Send(new GetUserByEmailQuery(request.Email));

            if(userExists != null)
                throw new Exception("User already exists");

            return await mediator.Send(new RegisterUserCommand(request));
        }
    }
}
