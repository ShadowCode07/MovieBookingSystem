using AutoMapper;
using UserService.src.UserServices.Application.DTOs.UserDTOs;
using UserService.src.UserServices.Application.Services.Abstraction;
using UserService.src.UserServices.Domain.Entities;
using UserService.src.UserServices.Infrastructure.Data.Repositories.Abstarction;

namespace UserService.src.UserServices.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(RegisterUserDto registerUserDto)
        {
            var user = _mapper.Map<User>(registerUserDto);
            await _userRepository.CreateAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public IEnumerable<UserDto> GetByEmail(string email)
        {
            var users = _userRepository.FindByFilter(user => user.Email == email);
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task UpdateAsync(UpdateUserDto updateUserDto)
        {
            var user = _mapper.Map<User>(updateUserDto);
            await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> ChangePasswordAsync(Guid id, ChangePasswordDto changePasswordDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            user.PasswordHash = changePasswordDto.NewPassword;
            await _userRepository.UpdateAsync(user);
            return true;
        }
    }
}
