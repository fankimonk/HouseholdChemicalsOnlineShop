using DataAccess.Enums;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class RolesPermissionsConfiguration : IEntityTypeConfiguration<RolePermissionEntity>
    {
        private readonly AuthorizationOptions _authorization;

        public RolesPermissionsConfiguration(AuthorizationOptions authorization)
        {
            _authorization = authorization;
        }

        public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
        {
            builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });

            builder.HasData(ParseRolePermissions());
        }

        private List<RolePermissionEntity> ParseRolePermissions()
        {
            //RolePermissions[] rolePermissions = [new RolePermissions { Role = "Admin", Permissions = ["Create", "Read", "Update", "Delete"] },
            //    new RolePermissions {Role = "User", Permissions = ["Read"]}]; //Костыль

            return _authorization.RolePermissions
                .SelectMany(rp => rp.Permissions
                    .Select(p => new RolePermissionEntity
                    {
                        RoleId = (int)Enum.Parse<Roles>(rp.Role),
                        PermissionId = (int)Enum.Parse<Permissions>(p)
                    }))
                .ToList();
        }
    }
}
