using Microsoft.AspNetCore.Mvc;
using MovieSeriesReview.CoreLayer.Entities;
using MovieSeriesReview.ServiceLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieSeriesReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _movieService.GetAllMoviesAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
                return NotFound();
            return Ok(movie);
        }
    }
}
