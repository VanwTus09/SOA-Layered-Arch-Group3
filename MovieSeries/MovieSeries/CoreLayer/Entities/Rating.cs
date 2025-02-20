namespace MovieSeries.CoreLayer.Entities
{
    public class Rating
    {
        public int Id { get; set; } // rating_id
        public int UserId { get; set; } // user_id (FK)
        public int MovieSeriesId { get; set; } // movie_series_id (FK)
        public decimal RatingValue { get; set; } // rating

        // Navigation properties
        public User User { get; set; }
        public MovieSerie MovieSeries { get; set; }
    }
}
