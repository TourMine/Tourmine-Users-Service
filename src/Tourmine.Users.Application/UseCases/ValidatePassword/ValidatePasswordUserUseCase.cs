using MediatR;
using System.Security.Authentication;
using Tourmine.Users.Application.Interfaces;
using Tourmine.Users.Application.Query.Users.GetByEmail;
using Tourmine.Users.Application.Requests;
using Tourmine.Users.Domain.Interfaces.Services;

namespace Tourmine.Users.Application.UseCases.ValidatePassword
{
    public class ValidatePasswordUserUseCase : BaseUseCase, IValidatePasswordUseCase
    {
        private readonly IPasswordHasherService _passwordHasherService;

        public ValidatePasswordUserUseCase(IMediator mediator, IPasswordHasherService passwordHasherService) : base(mediator)
        {
            _passwordHasherService = passwordHasherService;
        }

        public async Task<bool> Execute(ValidatePasswordRequest request)
        {
            var user = await mediator.Send(new GetUserByEmailQuery(request.Email));

            if (user == null)
                throw new Exception("user not found");

            bool isValid = _passwordHasherService.VerifyPassword(request.Password, user.Password);

            if(!isValid)
                throw new AuthenticationException("invalid password");

            return isValid;
        }
    }
}
