using MovieSeries.CoreLayer.Entities;
using System.Data;
using MovieSeries.RepositoryLayer.Interfaces;
using System.Collections.Generic;
using Dapper;
using System.Threading.Tasks;

namespace MovieSeries.RepositoryLayer
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IDbConnection _dbConnection;

        public MovieRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<MovieSerie>> GetAllMoviesAsync()
        {
            return await _dbConnection.QueryAsync<MovieSerie>("SELECT * FROM MoviesSeries");
        }

        public async Task<MovieSerie> GetMovieByIdAsync(int id)
        {
            var sql = "SELECT * FROM MoviesSeries WHERE movie_series_id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<MovieSerie>(sql, new { Id = id });
        }

        public async Task AddMovieAsync(MovieSerie movie)
        {
            var sql = "INSERT INTO MoviesSeries (title, genre, release_date, description) VALUES (@Title, @Genre, @ReleaseDate, @Description)";
            await _dbConnection.ExecuteAsync(sql, movie);
        }

        public async Task UpdateMovieAsync(MovieSerie movie)
        {
            var sql = "UPDATE MoviesSeries SET title = @Title, genre = @Genre, release_date = @ReleaseDate, description = @Description WHERE movie_series_id = @Id";
            await _dbConnection.ExecuteAsync(sql, movie);
        }

        public async Task DeleteMovieAsync(int id)
        {
            var sql = "DELETE FROM MoviesSeries WHERE movie_series_id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<MovieSerie>> GetTopRatedMoviesWithSpAsync(int topCount)
        {
            return await _dbConnection.QueryAsync<MovieSerie>(
                "GetTopRatedMovies",
                new { TopCount = topCount },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
