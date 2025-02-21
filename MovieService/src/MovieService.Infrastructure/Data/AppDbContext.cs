using Microsoft.EntityFrameworkCore;
using MovieService.src.MovieService.Domain.Entities;

namespace MovieService.src.MovieService.Infrastructure.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
