using AutoMapper;
using MovieService.src.MovieService.Application.DTOs.MovieDTOs;
using MovieService.src.MovieService.Application.Services.Abstraction;
using MovieService.src.MovieService.Domain.Entities;
using MovieService.src.MovieService.Infrastructure.Repositores.Abstraction;

namespace MovieService.src.MovieService.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepositroy _movieRepositroy;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepositroy movieRepositroy, IMapper mapper)
        {
            _movieRepositroy = movieRepositroy;
            _mapper = mapper;
        }

        public async Task CreateAsync(MovieCreateDto movieCreateDto)
        {
            var movie = _mapper.Map<Movie>(movieCreateDto);
            await _movieRepositroy.CreateAsync(movie);
        }

        public async Task DeleteAsync(Guid Id)
        {
            await _movieRepositroy.DeleteByIdAsync(Id);
        }

        public async Task<IEnumerable<MovieReadDto>> GetAllAsync()
        {
           var movies = await _movieRepositroy.GetAllAsync();
            return _mapper.Map<IEnumerable<MovieReadDto>>(movies);
        }

        public async Task<MovieReadDto> GetByIdAsync(Guid id)
        {
            var movie = await _movieRepositroy.GetByIdAsync(id);
            return _mapper.Map<MovieReadDto>(movie);
        }

        public IEnumerable<MovieReadDto> GetByTitle(string name)
        {
            var movies = _movieRepositroy.FindByFilter(movie => movie.Title == name);
            return _mapper.Map<IEnumerable<MovieReadDto>>(movies);
        }

        public async Task UpdateAsync(MovieCreateDto movieCreateDto)
        {
            var movie = _mapper.Map<Movie>(movieCreateDto);
            await _movieRepositroy.UpdateAsync(movie);
        }
    }
}
