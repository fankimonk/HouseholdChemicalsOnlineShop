using Application.Services;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Contracts.User;
using Microsoft.AspNetCore.Authorization;
using Application.Authorization;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly UsersService _usersService;

        public AuthController(IUsersRepository usersRepo, UsersService usersService) 
        {
            _usersRepository = usersRepo;
            _usersService = usersService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var user = await _usersService.Register(request.UserName, request.Email, request.Password);
            if (user == null) return BadRequest();
            return Ok(new UserResponse(user.UserName, user.Email, user.Role!.Name));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            var result = await _usersService.Login(request.Email, request.Password);

            if (result.Error != null) return BadRequest(result.Error);

            HttpContext.Response.Cookies.Append("tasty-cookies", result.Token);

            return Ok();
        }

        [HttpGet("check")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> CheckAuth()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == CustomClaims.UserId);
            var user = await _usersRepository.GetByIdAsync(int.Parse(userId!.Value));
            return Ok(new UserResponse(user!.UserName, user.Email, user.Role!.Name));
        }

        [HttpPost("logout")]
        [Authorize(Policy = "UserPolicy")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("tasty-cookies");
            return Ok();
        }
    }
}
