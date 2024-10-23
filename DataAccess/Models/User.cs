namespace DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }

        private User(string userName, string passwordHash, string email)
        {
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
        }

        public static User Create(string userName, string passwordHash, string email)
        {
            return new User(userName, passwordHash, email);
        }
    }
}
