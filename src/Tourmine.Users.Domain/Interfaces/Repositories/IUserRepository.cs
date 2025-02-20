using Tourmine.Users.Domain.DTO;
using Tourmine.Users.Domain.Entities;

namespace Tourmine.Users.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> Create(User user);
        Task<bool> Update(Guid id, UpdateUserDTO user);
        Task<User> GetById(Guid id);
        Task<User> GetByEmail(string email);
    }
}
