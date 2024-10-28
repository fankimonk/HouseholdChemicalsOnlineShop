using DataAccess.Enums;

namespace API.Interfaces
{
    public interface IPermissionService
    {
        Task<HashSet<Permissions>> GetPermissionsAsync(int id);
    }
}