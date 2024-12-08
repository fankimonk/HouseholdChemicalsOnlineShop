using Application.Helpers;
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

        public async Task<RegistrationResult> Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            if (await _usersRepository.UsernameExistsAsync(userName)) return RegistrationResult.UsernameTaken;
            if (await _usersRepository.EmailExistsAsync(email)) return RegistrationResult.EmailTaken;

            var user = new User { UserName = userName, PasswordHash = hashedPassword, Email = email, RoleId = (int)Roles.Admin };
            var cart = new Cart { User = user };
            user.Cart = cart;

            var createdUser = await _usersRepository.CreateAsync(user);
            if (createdUser == null) return RegistrationResult.FailedToCreate;

            return RegistrationResult.Succeed(createdUser);
        }

        public async Task<AuthorizationResult> Login(string email, string password)
        {
            var user = await _usersRepository.GetByEmailAsync(email);
            if (user == null)
            {
                return AuthorizationResult.UserNotFound;
            }

            var result = _passwordHasher.Verify(password, user.PasswordHash);
            if (result == false)
            {
                return AuthorizationResult.WrongPassword;
            }

            return AuthorizationResult.Succeed(_jwtProvider.GenerateToken(user));
        }
    }
}
