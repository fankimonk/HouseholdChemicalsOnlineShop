using System.ComponentModel.DataAnnotations;

namespace API.Contracts.User
{
    public record LoginUserRequest(
        [Required] string Email,
        [Required] string Password
        );
}
