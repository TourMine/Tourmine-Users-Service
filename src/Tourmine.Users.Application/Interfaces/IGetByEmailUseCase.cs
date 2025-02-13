using Tourmine.Users.Application.Responses;

namespace Tourmine.Users.Application.Interfaces
{
    public interface IGetByEmailUseCase
    {
        Task<UserResponse> Execute(string email);
    }
}
