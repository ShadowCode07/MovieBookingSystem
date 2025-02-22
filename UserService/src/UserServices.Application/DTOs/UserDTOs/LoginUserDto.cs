using System.ComponentModel.DataAnnotations;

namespace UserService.src.UserServices.Application.DTOs.UserDTOs
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
