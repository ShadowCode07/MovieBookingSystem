using MovieService.src.MovieService.Application.DTOs.MovieDTOs;

namespace MovieService.src.MovieService.Application.Services.Abstraction
{
    public interface IMovieService
    {
        Task<MovieReadDto> GetByIdAsync(Guid id);
        Task<IEnumerable<MovieReadDto>> GetAllAsync();
        Task CreateAsync(MovieCreateDto movieCreateDto);
        Task UpdateAsync(MovieCreateDto movieCreateDto);
        Task DeleteAsync(Guid id);
        IEnumerable<MovieReadDto> GetByTitle(string name);
    }
}
