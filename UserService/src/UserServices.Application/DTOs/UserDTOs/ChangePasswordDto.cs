﻿using System.ComponentModel.DataAnnotations;

namespace UserService.src.UserServices.Application.DTOs.UserDTOs
{
    public class ChangePasswordDto
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string NewPassword { get; set; }
    }
}
