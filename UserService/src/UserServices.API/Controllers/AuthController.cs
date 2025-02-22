using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.src.UserServices.Application.DTOs.UserDTOs;
using UserService.src.UserServices.Application.Services.Abstraction;

namespace UserService.src.UserServices.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            await _userService.CreateAsync(registerUserDto);
            return Ok("User registered successfully.");
        }

        [Authorize]
        [HttpPost("change-password/{id:guid}")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody] ChangePasswordDto changePasswordDto)
        {
            var success = await _userService.ChangePasswordAsync(id, changePasswordDto);
            if (!success)
            {
                return BadRequest("Failed to change password.");
            }
            return Ok("Password changed successfully.");
        }
    }
}
