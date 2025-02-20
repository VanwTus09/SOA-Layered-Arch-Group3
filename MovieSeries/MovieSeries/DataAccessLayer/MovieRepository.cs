using Microsoft.EntityFrameworkCore;
using MovieSeries.CoreLayer.Entities;
using MovieSeries.CoreLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieSeries.DataAccessLayer
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieSerie>> GetAllMoviesAsync()
        {
            return await _context.MoviesSeries.ToListAsync();
        }

        public async Task<MovieSerie> GetMovieByIdAsync(int id)
        {
            return await _context.MoviesSeries.FindAsync(id);
        }

        public async Task AddMovieAsync(MovieSerie movie)
        {
            await _context.MoviesSeries.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(MovieSerie movie)
        {
            _context.MoviesSeries.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _context.MoviesSeries.FindAsync(id);
            if (movie != null)
            {
                _context.MoviesSeries.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MovieSerie>> GetTopRatedMoviesWithSpAsync(int topCount)
        {
            return await _context.MoviesSeries.FromSqlRaw("EXEC GetTopRatedMovies @top_count = {0}", topCount).ToListAsync();
        }
    }
}
