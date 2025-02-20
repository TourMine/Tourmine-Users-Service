using MediatR;
using Tourmine.Users.Domain.DTO;
using Tourmine.Users.Domain.Interfaces.Repositories;
using Tourmine.Users.Domain.Interfaces.Services;

namespace Tourmine.Users.Application.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasherService _passwordHasherService;

        public UpdateUserCommandHandler(IUserRepository userRepository, IPasswordHasherService passwordHasherService)
        {
            _userRepository = userRepository;
            _passwordHasherService = passwordHasherService;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UpdateUserDTO
            {
                Name = request.Request?.Name,
                Email = request.Request?.Email,
                Password = _passwordHasherService.HashPassword(request.Request?.Password),
            };

            return await _userRepository.Update(request.Id, user);
        }
    }
}
