using System.ComponentModel.DataAnnotations;

namespace API.Contracts.User
{
    public record RegisterUserRequest(
        [Required] string UserName,
        [Required] string Email,
        [Required] string Password
        );
}
