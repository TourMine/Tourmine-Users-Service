using MediatR;
using Tourmine.Users.Application.Responses;

namespace Tourmine.Users.Application.Query.Users.GetById
{
    public class GetByIdUserQuery : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
        public GetByIdUserQuery(Guid id)
        {
            Id = id;
        }
    }
}
