using Domain.Models;

namespace Application.Interfaces
{
    public interface IUsersService
    {
        Task<string> Login(string email, string password);
        Task<User?> Register(string userName, string email, string password);
    }
}