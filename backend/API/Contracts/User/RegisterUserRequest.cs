﻿using System.ComponentModel.DataAnnotations;

namespace API.Contracts.User
{
    public record RegisterUserRequest(

        [Required]
        [MinLength(5, ErrorMessage = "Username must have at least 5 characters")]
        [MaxLength(20, ErrorMessage = "Username must not have more than 20 characters")]
        string UserName,

        [Required] 
        [EmailAddress(ErrorMessage = "Input email address")]
        string Email,

        [Required]
        [MinLength(8, ErrorMessage = "Password must have at least 8 characters")]
        string Password

        );
}
