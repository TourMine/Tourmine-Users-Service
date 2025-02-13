using MediatR;
using Tourmine.Users.Application.Interfaces;
using Tourmine.Users.Application.Query;
using Tourmine.Users.Application.Query.Users.GetById;
using Tourmine.Users.Application.Responses;

namespace Tourmine.Users.Application.UseCases.User.GetById
{
    public class GetByIdUseCase : BaseUseCase, IGetByIdUseCase
    {
        public GetByIdUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<UserResponse> Execute(Guid id)
        {
            return await mediator.Send(new GetByIdUserQuery(id));
        }
    }
}
