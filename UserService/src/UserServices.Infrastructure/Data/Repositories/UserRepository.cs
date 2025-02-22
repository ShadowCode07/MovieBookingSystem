using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserService.src.UserServices.Domain.Entities;
using UserService.src.UserServices.Infrastructure.Data.Repositories.Abstarction;

namespace UserService.src.UserServices.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public UserRepository(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task CreateAsync(User user)
        {
            var result = await _userManager.CreateAsync(user, user.PasswordHash);

            await _userManager.AddToRoleAsync(user, "User");
        }

        public async Task<IdentityResult> CreateAsync(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            return result;
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if(user != null)
            {
                var result = await _userManager.DeleteAsync(user);
            }
            else
            {
                throw new ArgumentException($"User with id: {id} does not exist");
            }
        }

        public IEnumerable<User> FindByFilter(Func<User, bool> predicate)
        {
            return _userManager.Users.Where(predicate).ToList();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<User>? GetByIdAsync(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<User> UpdateAsync(User user)
        {
            var existingUser = await _userManager.FindByIdAsync(user.Id.ToString());

            if (existingUser == null)
            {
                throw new ArgumentException("User with that id does not exist");
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.UserName = user.UserName;
            existingUser.UpdatedAt = DateTime.UtcNow;

            var result = await _userManager.UpdateAsync(existingUser);
            
            if (!result.Succeeded)
            {
                throw new Exception("Failed to update user.");
            }
                
            return existingUser;
        }
    }
}
