using UserService.src.UserServices.Application.DTOs.UserDTOs;

namespace UserService.src.UserServices.Application.Services.Abstraction
{
    public interface IUserService
    {
        Task CreateAsync(RegisterUserDto registerUserDto);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(Guid id);
        IEnumerable<UserDto> GetByEmail(string email);
        Task UpdateAsync(UpdateUserDto updateUserDto);
        Task<bool> ChangePasswordAsync(Guid id, ChangePasswordDto changePasswordDto);
    }
}
