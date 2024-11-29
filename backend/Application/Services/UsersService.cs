using Application.Interfaces;
using DataAccess.Interfaces;
using Domain.Enums;
using Domain.Models;

namespace Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ICartsRepository _cartsRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UsersService(IUsersRepository usersRepository, ICartsRepository cartsRepository,
            IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _usersRepository = usersRepository;
            _cartsRepository = cartsRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<User?> Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = new User { UserName = userName, PasswordHash = hashedPassword, Email = email, RoleId = (int)Roles.User };
            var cart = new Cart { User = user };
            user.Cart = cart;

            return await _usersRepository.CreateAsync(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _usersRepository.GetByEmailAsync(email);
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
