using MovieSeries.CoreLayer.Entities;

namespace MovieSeries.ServiceLayer.Interfaces
{
    public interface IRatingService
    {
        Task<IEnumerable<Rating>> GetAllRatingsAsync();
        Task<Rating> GetRatingByIdAsync(int id);
        Task<IEnumerable<Rating>> GetRatingsByMovieAsync(int movieSeriesId);
        Task AddRatingAsync(Rating rating);
        Task UpdateRatingAsync(Rating rating);
        Task DeleteRatingAsync(int id);
    }
}
