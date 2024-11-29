using Domain.Enums;

namespace Application.Interfaces
{
    public interface IPermissionService
    {
        Task<HashSet<Permissions>> GetPermissionsAsync(int id);
    }
}