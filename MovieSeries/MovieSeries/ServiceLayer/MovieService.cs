using MovieSeries.CoreLayer.Entities;
using MovieSeries.CoreLayer.Interfaces;
using MovieSeries.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSeries.ServiceLayer
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // Lấy danh sách tất cả phim
        public async Task<IEnumerable<MovieSerie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllMoviesAsync();
        }

        // Lấy phim theo ID
        public async Task<MovieSerie> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);
            if (movie == null)
            {
                throw new KeyNotFoundException($"No movie found with ID {id}");
            }
            return movie;
        }

        // Thêm phim mới với kiểm tra hợp lệ
        public async Task AddMovieAsync(MovieSerie movie)
        {
            if (movie == null || string.IsNullOrWhiteSpace(movie.Title))
            {
                throw new ArgumentException("Movie information is invalid.");
            }

            var existingMovies = await _movieRepository.GetAllMoviesAsync();
            if (existingMovies.Any(m => m.Title.Equals(movie.Title, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("A movie with the same title already exists.");
            }

            await _movieRepository.AddMovieAsync(movie);
        }

        // Cập nhật thông tin phim
        public async Task UpdateMovieAsync(MovieSerie movie)
        {
            if (movie == null || string.IsNullOrWhiteSpace(movie.Title))
            {
                throw new ArgumentException("Movie information is invalid.");
            }

            var existingMovie = await _movieRepository.GetMovieByIdAsync(movie.Id);
            if (existingMovie == null)
            {
                throw new KeyNotFoundException($"No movie found with ID {movie.Id}");
            }

            await _movieRepository.UpdateMovieAsync(movie);
        }

        // Xóa phim
        public async Task DeleteMovieAsync(int id)
        {
            var existingMovie = await _movieRepository.GetMovieByIdAsync(id);
            if (existingMovie == null)
            {
                throw new KeyNotFoundException($"No movie found with ID {id}");
            }

            await _movieRepository.DeleteMovieAsync(id);
        }

        // Lấy danh sách phim có đánh giá cao nhất bằng Stored Procedure
        public async Task<IEnumerable<MovieSerie>> GetTopRatedMoviesWithSpAsync(int topCount)
        {
            try
            {
                return await _movieRepository.GetTopRatedMoviesWithSpAsync(topCount);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving top-rated movies.", ex);
            }
        }
    }
}
