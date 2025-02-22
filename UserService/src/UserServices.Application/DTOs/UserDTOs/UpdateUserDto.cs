using System.ComponentModel.DataAnnotations;

namespace UserService.src.UserServices.Application.DTOs.UserDTOs
{
    public class UpdateUserDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
