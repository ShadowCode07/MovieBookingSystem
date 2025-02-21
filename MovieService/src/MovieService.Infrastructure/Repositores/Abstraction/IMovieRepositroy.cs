using MovieService.src.MovieService.Application.DTOs.MovieDTOs;
using MovieService.src.MovieService.Domain.Entities;

namespace MovieService.src.MovieService.Infrastructure.Repositores.Abstraction
{
    public interface IMovieRepositroy : IRepository<Movie>
    {
    }
}
