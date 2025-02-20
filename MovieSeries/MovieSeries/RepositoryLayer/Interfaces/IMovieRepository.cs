using MovieSeries.CoreLayer.Entities;

namespace MovieSeries.RepositoryLayer.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieSerie>> GetAllMoviesAsync();
        Task AddMovieAsync(MovieSerie movie);
        Task<IEnumerable<MovieSerie>> GetTopRatedMoviesWithSpAsync(int topCount);
    }
}
