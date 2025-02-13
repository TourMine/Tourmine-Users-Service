using MediatR;
using Tourmine.Users.Application.Interfaces;
using Tourmine.Users.Application.Query.Users.GetByEmail;
using Tourmine.Users.Application.Responses;

namespace Tourmine.Users.Application.UseCases.User.GetByEmail
{
    public class GetByEmailUseCase : BaseUseCase, IGetByEmailUseCase
    {
        public GetByEmailUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<UserResponse> Execute(string email)
        {
            return await mediator.Send(new GetUserByEmailQuery(email));
        }
    }
}
