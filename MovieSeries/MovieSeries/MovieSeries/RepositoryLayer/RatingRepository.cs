using Microsoft.EntityFrameworkCore;
using MovieSeries.CoreLayer.Entities;
using MovieSeries.DataAccessLayer;
using MovieSeries.RepositoryLayer.Interfaces;

namespace MovieSeries.RepositoryLayer
{
    public class RatingRepository : IRatingRepository
    {
        private readonly AppDbContext _context;

        public RatingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rating>> GetAllAsync()
        {
            return await _context.Ratings
                .Include(r => r.User)
                .Include(r => r.MovieSeries)
                .ToListAsync();
        }

        public async Task<Rating> GetByIdAsync(int id)
        {
            return await _context.Ratings
                .Include(r => r.User)
                .Include(r => r.MovieSeries)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Rating entity)
        {
            await _context.Ratings.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rating entity)
        {
            _context.Ratings.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating != null)
            {
                _context.Ratings.Remove(rating);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Rating>> GetRatingsByMovieAsync(int movieSeriesId)
        {
            return await _context.Ratings.Where(r => r.MovieSeriesId == movieSeriesId).ToListAsync();
        }

        public Rating GetRatingById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddRating(Rating rating)
        {
            throw new NotImplementedException();
        }
    }
}
