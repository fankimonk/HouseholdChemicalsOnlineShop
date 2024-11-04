using Application.Services;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Contracts.User;

namespace API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepo;
        private readonly UsersService _usersService;

        public UsersController(IUsersRepository usersRepo, UsersService usersService) 
        {
            _usersRepo = usersRepo;
            _usersService = usersService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var user = await _usersService.Register(request.UserName, request.Email, request.Password);
            if (user == null) return BadRequest();
            return Ok(new UserResponse(user.UserName, user.Email, user.RoleId));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            var token = await _usersService.Login(request.Email, request.Password);

            HttpContext.Response.Cookies.Append("tasty-cookies", token);

            return Ok();
        }
    }
}
