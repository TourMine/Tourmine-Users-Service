using Tourmine.Users.Application.Requests;

namespace Tourmine.Users.Application.Interfaces
{
    public interface IValidatePasswordUseCase 
    {
        Task<bool> Execute(ValidatePasswordRequest request);
    }
}
