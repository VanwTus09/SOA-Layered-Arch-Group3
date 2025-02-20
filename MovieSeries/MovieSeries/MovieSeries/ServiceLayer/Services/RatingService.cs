using MovieSeries.CoreLayer.Entities;
using MovieSeries.RepositoryLayer.Interfaces;
using MovieSeries.ServiceLayer.Interfaces;

namespace MovieSeries.ServiceLayer.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<IEnumerable<Rating>> GetAllRatingsAsync()
        {
            return await _ratingRepository.GetAllAsync();
        }

        public async Task<Rating> GetRatingByIdAsync(int id)
        {
            return await _ratingRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Rating>> GetRatingsByMovieAsync(int movieSeriesId)
        {
            return await _ratingRepository.GetRatingsByMovieAsync(movieSeriesId);
        }

        public async Task AddRatingAsync(Rating rating)
        {
            await _ratingRepository.AddAsync(rating);
        }

        public async Task UpdateRatingAsync(Rating rating)
        {
            await _ratingRepository.UpdateAsync(rating);
        }

        public async Task DeleteRatingAsync(int id)
        {
            await _ratingRepository.DeleteAsync(id);
        }
    }
}
