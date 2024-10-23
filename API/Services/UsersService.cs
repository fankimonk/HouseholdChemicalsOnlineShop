using API.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace API.Services
{
    public class UsersService
    {
        private readonly IUsersRepository _usersRepo;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UsersService(IUsersRepository usersRepo, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _usersRepo = usersRepo;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<User?> Register(string userName, string email,  string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(userName, hashedPassword, email);

            return await _usersRepo.CreateAsync(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _usersRepo.GetByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("user not found"); //Поменять
            }

            var result = _passwordHasher.Verify(password, user.PasswordHash);
            if (result == false)
            {
                throw new Exception("failed to login"); //Поменять
            }

            return _jwtProvider.GenerateToken(user);
        }
    }
}
