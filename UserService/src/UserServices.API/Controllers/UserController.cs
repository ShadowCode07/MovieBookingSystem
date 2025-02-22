using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserService.src.UserServices.Application.DTOs.UserDTOs;
using UserService.src.UserServices.Application.Services.Abstraction;

namespace UserService.src.UserServices.API.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        [HttpGet("email/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            var users = _userService.GetByEmail(email);
            return Ok(users);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            await _userService.UpdateAsync(updateUserDto);
            return Ok("User updated successfully.");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
