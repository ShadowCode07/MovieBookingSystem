using System.ComponentModel.DataAnnotations;

namespace MovieService.src.MovieService.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}
