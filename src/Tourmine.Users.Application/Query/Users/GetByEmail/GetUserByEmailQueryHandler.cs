using MediatR;
using Tourmine.Users.Application.Responses;
using Tourmine.Users.Domain.Interfaces.Repositories;

namespace Tourmine.Users.Application.Query.Users.GetByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetByEmail(request.Email);

            if (result == null)
                return null;

            return new UserResponse
            {
                Id = result.Id,
                Name = result.Name,
                Email = result.Email,
                UserType = result.UserType,
                Password =result.Password,
                CreatedDate = result.CreatedDate
            };
        }
    }
}
