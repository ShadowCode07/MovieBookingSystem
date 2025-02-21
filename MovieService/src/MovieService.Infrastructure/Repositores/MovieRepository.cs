using Microsoft.EntityFrameworkCore;
using MovieService.src.MovieService.Domain.Entities;
using MovieService.src.MovieService.Infrastructure.Data;
using MovieService.src.MovieService.Infrastructure.Repositores.Abstraction;

namespace MovieService.src.MovieService.Infrastructure.Repositores
{
    public class MovieRepository : Repository<Movie>, IMovieRepositroy
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
