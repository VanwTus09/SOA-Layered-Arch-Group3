using MovieSeriesReview.CoreLayer.Entities;
using MovieSeriesReview.CoreLayer.Interfaces;
using MovieSeriesReview.ServiceLayer.Interfaces;

namespace MovieSeriesReview.ServiceLayer.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // Lấy danh sách tất cả phim (CRUD)
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllMoviesAsync();
        }

        // Thêm phim mới với kiểm tra hợp lệ
        public async Task AddMovieAsync(Movie movie)
        {
            var existingMovies = await _movieRepository.GetAllMoviesAsync();
            if (existingMovies.Any(m => m.Title == movie.Title))
            {
                throw new ArgumentException("A movie with the same title already exists.");
            }
            await _movieRepository.AddMovieAsync(movie);
        }

        // Lấy danh sách phim có đánh giá cao nhất bằng Stored Procedure
        public async Task<IEnumerable<Movie>> GetTopRatedMoviesWithSpAsync(int topCount)
        {
            try
            {
                return await _movieRepository.GetTopRatedMoviesWithSpAsync(topCount);
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc xử lý thông báo thân thiện
                throw new ApplicationException("An error occurred while retrieving top-rated movies.", ex);
            }
        }
    }
}
