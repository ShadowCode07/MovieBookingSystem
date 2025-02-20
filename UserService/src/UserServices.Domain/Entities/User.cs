using Microsoft.AspNetCore.Identity;
using UserService.src.UserServices.Domain.ValueObjects;

namespace UserService.src.UserServices.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Email EmailAddress { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}
