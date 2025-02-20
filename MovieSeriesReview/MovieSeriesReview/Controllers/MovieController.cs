using Microsoft.AspNetCore.Mvc;
using MovieSeriesReview.CoreLayer.Entities;
using MovieSeriesReview.ServiceLayer;
using MovieSeriesReview.ServiceLayer.Interfaces;
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
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            return Ok(await _movieService.GetAllMoviesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
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
        public async Task<ActionResult<IEnumerable<Movie>>> GetTopRatedMovies(int count)
        {
            return Ok(await _movieService.GetTopRatedMoviesWithSpAsync(count));
        }
    }
}
