using Tourmine.Users.Application.Requests;

namespace Tourmine.Users.Application.Interfaces
{
    public interface IRegisterUserUseCase
    {
        Task<bool> Execute(RegisterRequest request);
    }
}