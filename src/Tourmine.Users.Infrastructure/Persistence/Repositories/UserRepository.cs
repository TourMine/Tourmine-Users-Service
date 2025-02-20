using Microsoft.EntityFrameworkCore;
using Tourmine.Users.Domain.DTO;
using Tourmine.Users.Domain.Entities;
using Tourmine.Users.Domain.Interfaces.Repositories;
using Tourmine.Users.Infrastructure.Context;

namespace Tourmine.Users.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(Guid id, UpdateUserDTO userEntity)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);

                if (userEntity.Name != null)
                {
                    user.Name = userEntity.Name;
                }

                if (userEntity.Email != null)
                {
                    user.Email = userEntity.Email;
                }

                if (userEntity.Password != null)
                {
                    user.Password = userEntity.Password;
                }

                var result = await _context.SaveChangesAsync();

                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetById(Guid id)
        {
            try
            {
                return await _context.Users.FindAsync(id);  
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
