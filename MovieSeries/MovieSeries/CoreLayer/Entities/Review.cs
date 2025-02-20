namespace MovieSeries.CoreLayer.Entities
{
    public class Review
    {
        public int Id { get; set; } // review_id
        public int UserId { get; set; } // user_id (FK)
        public int MovieSeriesId { get; set; } // movie_series_id (FK)
        public string ReviewText { get; set; } // review_text
        public DateTime ReviewDate { get; set; } = DateTime.Now; // review_date

        // Navigation properties
        public User User { get; set; }
        public MovieSerie MovieSeries { get; set; }
    }
}
