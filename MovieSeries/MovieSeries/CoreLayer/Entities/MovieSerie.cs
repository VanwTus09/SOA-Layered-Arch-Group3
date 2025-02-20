namespace MovieSeries.CoreLayer.Entities
{
    public class MovieSerie
    {
        public int Id { get; set; } // movie_series_id
        public string Title { get; set; } // title
        public string Genre { get; set; } // genre
        public DateTime? ReleaseDate { get; set; } // release_date
        public string Description { get; set; } // description

        // Navigation properties
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; } = new List<MovieSeriesTag>();
    }
}
