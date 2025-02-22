using UserService.src.UserServices.Application.DTOs.UserDTOs;

namespace UserService.src.UserServices.Application.Services.Abstraction
{
    public interface IAuthService
    {
        Task<string> AuthenticateUserAsync(LoginUserDto loginDto);
    }
}
