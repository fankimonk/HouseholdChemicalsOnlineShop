namespace DataAccess.Models
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }

        public List<RoleEntity> Roles { get; set; } = [];

        private UserEntity(string userName, string passwordHash, string email)
        {
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
        }

        public static UserEntity Create(string userName, string passwordHash, string email)
        {
            return new UserEntity(userName, passwordHash, email);
        }
    }
}
