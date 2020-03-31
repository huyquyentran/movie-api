using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.Models;
using MovieApp.Repositories;

namespace MovieApp.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IRepository<Movie> movieRepository;

        public MoviesService(IRepository<Movie> movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public Task<List<Movie>> GetAllMoviesAsync()
        {
            return movieRepository.GetAllAsync();
        }

        public Task<Movie> GetMovieByIdAsync(int id)
        {
            return movieRepository.GetAsync(id);
        }

        public async Task<int> AddMovieAsync(Movie movie)
        {
            await movieRepository.InsertAsync(movie);
            return movie.Id;
        }

        public async Task UpdateAsync(int id, Movie newMovie)
        {
            var movie = await movieRepository.GetAsync(id);
            await movieRepository.UpdateAsync(newMovie);
        }
    }
}