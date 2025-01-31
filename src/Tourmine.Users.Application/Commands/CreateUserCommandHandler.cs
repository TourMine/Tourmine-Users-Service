using MediatR;
using Tourmine.Users.Domain.Entities;
using Tourmine.Users.Domain.Interfaces.Repositories;

namespace Tourmine.Users.Application.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = ConvertToEntity(request);
            return await _repository.Create(entity);
        }

        private User ConvertToEntity(CreateUserCommand request)
        {
            return new User
            {
                Name = request.Request.Name,
                Email = request.Request.Email,
                Password = request.Request.Password,
                UserType = request.Request.UserType
            };
        }
    }
}
