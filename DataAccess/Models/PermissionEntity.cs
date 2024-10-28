﻿namespace DataAccess.Models
{
    public class PermissionEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<RoleEntity> Roles { get; set; } = [];
    }
}
