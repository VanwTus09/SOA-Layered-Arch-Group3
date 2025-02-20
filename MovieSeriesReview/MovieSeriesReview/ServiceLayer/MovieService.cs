using MovieSeriesReview.CoreLayer.Entities;
using MovieSeriesReview.CoreLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieSeriesReview.ServiceLayer
{
    public class MovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllMoviesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetMovieByIdAsync(id);
        }
    }
}
