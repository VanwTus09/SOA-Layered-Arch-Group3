using Microsoft.AspNetCore.Mvc;
using MovieSeries.CoreLayer.Entities;
using MovieSeries.ServiceLayer;
using MovieSeries.ServiceLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieSeriesReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieSerie>>> GetAllMovies()
        {
            return Ok(await _movieService.GetAllMoviesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] MovieSerie movie)
        {
            try
            {
                await _movieService.AddMovieAsync(movie);
                return Ok("Movie added successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("top-rated/{count}")]
        public async Task<ActionResult<IEnumerable<MovieSerie>>> GetTopRatedMovies(int count)
        {
            return Ok(await _movieService.GetTopRatedMoviesWithSpAsync(count));
        }
    }
}
