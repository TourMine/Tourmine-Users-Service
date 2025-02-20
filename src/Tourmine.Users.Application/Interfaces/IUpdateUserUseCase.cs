using Tourmine.Users.Application.Requests;

namespace Tourmine.Users.Application.Interfaces
{
    public interface IUpdateUserUseCase
    {
        Task<bool> Execute(Guid id,UpdateUserRequest request);
    }
}
