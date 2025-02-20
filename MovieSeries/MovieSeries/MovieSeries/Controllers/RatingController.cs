using Microsoft.AspNetCore.Mvc;
using MovieSeries.CoreLayer.Entities;
using MovieSeries.ServiceLayer.Interfaces;

namespace MovieSeries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRatings()
        {
            var ratings = await _ratingService.GetAllRatingsAsync();
            return Ok(ratings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRatingById(int id)
        {
            var rating = await _ratingService.GetRatingByIdAsync(id);
            if (rating == null) return NotFound();
            return Ok(rating);
        }

        [HttpGet("movie/{movieSeriesId}")]
        public async Task<IActionResult> GetRatingsByMovie(int movieSeriesId)
        {
            var ratings = await _ratingService.GetRatingsByMovieAsync(movieSeriesId);
            return Ok(ratings);
        }

        [HttpPost]
        public async Task<IActionResult> AddRating([FromBody] Rating rating)
        {
            if (rating == null) return BadRequest();
            await _ratingService.AddRatingAsync(rating);
            return CreatedAtAction(nameof(GetRatingById), new { id = rating.Id }, rating);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRating(int id, [FromBody] Rating rating)
        {
            if (rating == null || id != rating.Id) return BadRequest();
            await _ratingService.UpdateRatingAsync(rating);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            await _ratingService.DeleteRatingAsync(id);
            return NoContent();
        }
    }
}
