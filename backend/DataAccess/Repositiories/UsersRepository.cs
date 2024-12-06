using Domain.Enums;
using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositiories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly OnlineShopDbContext _dbContext;

        public UsersRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> CreateAsync(User user)
        {
            var createdUser = await _dbContext.Users.AddAsync(user);
            if (createdUser == null) return null;
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Users.AsNoTracking().Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == createdUser.Entity.Id);
        }

        public async Task DeleteAsync(int id)
        {
            await _dbContext.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
            return user != null;
        }

        public async Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _dbContext.Users.AsNoTracking().Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<HashSet<Permissions>> GetUserPermissions(int id)
        {
            var user = await _dbContext.Users.AsNoTracking()
                .Include(u => u.Role)
                .ThenInclude(r => r!.Permissions)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return [];

            return user.Role!.Permissions.Select(p => (Permissions)p.Id).ToHashSet();
        }

        public async Task<User?> UpdateAsync(int id, User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UsernameExistsAsync(string userName)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserName == userName);
            return user != null;
        }
    }
}
