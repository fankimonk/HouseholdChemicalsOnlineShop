using DataAccess.Enums;
using Microsoft.AspNetCore.Authorization;

namespace API.Authorization
{
    public class PermissionRequirement(Permissions[] permissions) : IAuthorizationRequirement
    {
        public Permissions[] Permissions { get; set; } = permissions;
    }
}
