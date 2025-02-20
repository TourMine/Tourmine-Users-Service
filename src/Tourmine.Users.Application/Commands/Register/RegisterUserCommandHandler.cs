using MediatR;
using Tourmine.Users.Domain.Entities;
using Tourmine.Users.Domain.Interfaces.Repositories;
using Tourmine.Users.Domain.Interfaces.Services;

namespace Tourmine.Users.Application.Commands.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasherService _passwordHasherService;

        public RegisterUserCommandHandler(IUserRepository repository, IPasswordHasherService passwordHasherService)
        {
            _repository = repository;
            _passwordHasherService = passwordHasherService;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var entity = ConvertToEntity(request);
            return await _repository.Create(entity);
        }

        private User ConvertToEntity(RegisterUserCommand request)
        {
            return new User
            {
                Name = request.Request.Name,
                Email = request.Request.Email,
                Password = _passwordHasherService.HashPassword(request.Request.Password),
                UserType = request.Request.UserType
            };
        }
    }
}
