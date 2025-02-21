using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieService.src.MovieService.Application.DTOs.MovieDTOs
{
    public class MovieReadDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
    }
}
