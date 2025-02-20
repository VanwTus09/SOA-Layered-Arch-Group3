using MovieSeries.CoreLayer.Entities;

namespace MovieSeries.RepositoryLayer.Interfaces
{
    public interface IRatingRepository : IRepository<Rating>
    {
        Task<IEnumerable<Rating>> GetRatingsByMovieAsync(int movieSeriesId);
        Rating GetRatingById(int id);
        void AddRating(Rating rating);
    }
}
