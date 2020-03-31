using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Repositories;
using MovieApp.Services;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await moviesService.GetAllMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var movie = await moviesService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound("Movie Not Found");
            }
            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(Movie movie)
        {
            await moviesService.AddMovieAsync(movie);
            return CreatedAtAction(nameof(GetOne), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, Movie movie)
        {
            movie.Id = id;
            await moviesService.UpdateAsync(id, movie);
            return NoContent();
        }

    }
}