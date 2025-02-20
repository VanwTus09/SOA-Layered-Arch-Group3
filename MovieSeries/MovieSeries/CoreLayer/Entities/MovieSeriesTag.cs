using Azure;
using MovieSeries.CoreLayer.Entities;


namespace MovieSeries.CoreLayer.Entities
{
    public class MovieSeriesTag
    {
        public int MovieSeriesId { get; set; } // movie_series_id (FK)
        public int TagId { get; set; } // tag_id (FK)

        // Navigation properties
        public MovieSerie MovieSerie { get; set; }
        public Tag Tag { get; set; }
    }
}
