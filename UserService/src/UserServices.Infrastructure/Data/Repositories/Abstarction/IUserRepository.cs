﻿using Microsoft.AspNetCore.Identity;
using UserService.src.UserServices.Domain.Entities;

namespace UserService.src.UserServices.Infrastructure.Data.Repositories.Abstarction
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task<IdentityResult> CreateAsync(User user, string password);   
        Task<User> UpdateAsync(User user);
        Task DeleteByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        IEnumerable<User> FindByFilter(Func<User, bool> predicate);
        Task<User>? GetByIdAsync(Guid id);
    }
}
