﻿namespace DataAccess.Models
{
    public class RoleEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<PermissionEntity> Permissions { get; set; } = [];
        public List<UserEntity> Users { get; set; } = [];
    }
}
