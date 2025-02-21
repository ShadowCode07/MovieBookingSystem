using AutoMapper;
using MovieService.src.MovieService.Application.DTOs.MovieDTOs;
using MovieService.src.MovieService.Domain.Entities;

namespace MovieService.src.MovieService.Application.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
                CreateMap<Movie, MovieCreateDto>().ReverseMap();
                CreateMap<Movie, MovieReadDto>().ReverseMap();
        }
    }
}
