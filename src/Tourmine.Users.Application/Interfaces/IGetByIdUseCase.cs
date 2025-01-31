using Tourmine.Users.Application.Responses;

namespace Tourmine.Users.Application.Interfaces
{
    public interface IGetByIdUseCase 
    {
        Task<UserResponse> Execute(Guid id);
    }
}
