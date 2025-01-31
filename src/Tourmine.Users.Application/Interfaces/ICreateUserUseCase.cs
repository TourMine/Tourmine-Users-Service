using Tourmine.Users.Application.Requests;

namespace Tourmine.Users.Application.Interfaces
{
    public interface ICreateUserUseCase
    {
        Task<bool> Execute(UserRequest request);
    }
}