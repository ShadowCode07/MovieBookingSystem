using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieService.src.MovieService.Application.DTOs.MovieDTOs;
using MovieService.src.MovieService.Application.Services.Abstraction;
using MovieService.src.MovieService.Domain.Entities;
using MovieService.src.MovieService.Infrastructure.Data;

namespace MovieService.src.MovieSerive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDto>>> GetMovies()
        {
            return Ok(await _movieService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDto>> GetMovie(Guid id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpGet("search/{title}")]
        public ActionResult<IEnumerable<MovieReadDto>> GetMoviesByTitle(string title)
        {
            var movies = _movieService.GetByTitle(title);
            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] MovieCreateDto movieCreateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _movieService.CreateAsync(movieCreateDto);
            return CreatedAtAction(nameof(GetMovie), new { id = movieCreateDto.Title }, movieCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(Guid id, [FromBody] MovieCreateDto movieUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _movieService.UpdateAsync(movieUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            await _movieService.DeleteAsync(id);
            return NoContent();
        }
    }
}
