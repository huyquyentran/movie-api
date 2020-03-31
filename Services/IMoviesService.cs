using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.Models;

namespace MovieApp.Services
{
    public interface IMoviesService
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<int> AddMovieAsync(Movie movie);
        Task UpdateAsync(int id, Movie newMovie);
    }
}