using Application.Interfaces;
using Domain.Enums;
using DataAccess.Interfaces;

namespace Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUsersRepository _usersRepo;

        public PermissionService(IUsersRepository usersRepo)
        {
            _usersRepo = usersRepo;
        }

        public Task<HashSet<Permissions>> GetPermissionsAsync(int id)
        {
            return _usersRepo.GetUserPermissions(id);
        }
    }
}
