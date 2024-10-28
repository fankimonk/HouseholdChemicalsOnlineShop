using DataAccess.Enums;
using DataAccess.Interfaces;
using DataAccess.Models;
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

        public async Task<UserEntity?> CreateAsync(UserEntity user)
        {
            if (user == null) return null;

            //var roleEntity = await _dbContext.Roles
            //    .SingleOrDefaultAsync(r => r.Id == (int)Roles.Admin)
            //    ?? throw new InvalidOperationException();

            //var newUser = UserEntity.Create(user.UserName, user.PasswordHash, user.Email);
            //newUser.Roles = [roleEntity];

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserEntity?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<HashSet<Permissions>> GetUserPermissions(int id)
        {
            var roles = await _dbContext.Users
                .AsNoTracking()
                .Include(u => u.Roles)
                .ThenInclude(r => r.Permissions)
                .Where(u => u.Id == id)
                .Select(u => u.Roles)
                .ToArrayAsync();

            return roles
                .SelectMany(r => r)
                .SelectMany(r => r.Permissions)
                .Select(p => (Permissions)p.Id)
                .ToHashSet();
        }

        public async Task<UserEntity?> UpdateAsync(int id, UserEntity user)
        {
            throw new NotImplementedException();
        }
    }
}
