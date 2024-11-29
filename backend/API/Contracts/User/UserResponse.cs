namespace API.Contracts.User
{
    public record UserResponse(
        string UserName,
        string Email,
        int RoleId
        );
}
