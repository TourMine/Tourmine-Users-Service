using MediatR;
using Tourmine.Users.Application.Responses;
using Tourmine.Users.Domain.Entities;
using Tourmine.Users.Domain.Interfaces.Repositories;

namespace Tourmine.Users.Application.Query.Users.GetById
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserResponse>
    {
        private readonly IUserRepository _repository;

        public GetByIdUserQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetById(request.Id);
            var response = ConvertToResponse(result);

            return response;
        }

        public UserResponse ConvertToResponse(User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                UserType = user.UserType,
                CreatedDate = user.CreatedDate,
                ModifiedDate = user.ModifiedDate
            };
        }
    }
}
