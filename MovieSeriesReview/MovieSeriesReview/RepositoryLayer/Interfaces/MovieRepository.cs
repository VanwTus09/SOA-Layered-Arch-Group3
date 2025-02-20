using MovieSeriesReview.CoreLayer.Entities;
using System.Data;
using MovieSeriesReview.RepositoryLayer.Interfaces;
using System.Collections.Generic;
using Dapper;




namespace MovieSeriesReview.RepositoryLayer.Interfaces
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IDbConnection _dbConnection;

        public MovieRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _dbConnection.QueryAsync<Movie>("SELECT * FROM Movies");
        }

        public async Task AddMovieAsync(Movie movie)
        {
            var sql = "INSERT INTO Movies (Title, Rating) VALUES (@Title, @Rating)";
            await _dbConnection.ExecuteAsync(sql, movie);
        }

        public async Task<IEnumerable<Movie>> GetTopRatedMoviesWithSpAsync(int topCount)
        {
            return await _dbConnection.QueryAsync<Movie>(
                "GetTopRatedMovies",
                new { TopCount = topCount },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
