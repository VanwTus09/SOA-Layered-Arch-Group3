using MovieSeries.CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieSeries.CoreLayer.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieSerie>> GetAllMoviesAsync();
        Task<MovieSerie> GetMovieByIdAsync(int id);
        Task AddMovieAsync(MovieSerie movie);
        Task UpdateMovieAsync(MovieSerie movie);
        Task DeleteMovieAsync(int id);
        Task<IEnumerable<MovieSerie>> GetTopRatedMoviesWithSpAsync(int topCount);
    }
}
