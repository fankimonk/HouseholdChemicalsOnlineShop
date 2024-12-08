using System.ComponentModel.DataAnnotations;

namespace API.Contracts.User
{
    public record LoginUserRequest(
        [Required]
        [EmailAddress(ErrorMessage = "Input email address")]
        string Email,

        [Required] 
        string Password
        );
}
