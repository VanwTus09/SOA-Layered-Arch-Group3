using MovieSeries.CoreLayer.Entities;

namespace MovieSeries.ServiceLayer.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieSerie>> GetAllMoviesAsync();
        Task<MovieSerie> GetMovieByIdAsync(int id);
        Task AddMovieAsync(MovieSerie movie);
        Task UpdateMovieAsync(MovieSerie movie);
        Task DeleteMovieAsync(int id);
        Task<IEnumerable<MovieSerie>> GetTopRatedMoviesWithSpAsync(int topCount);
    }
}
