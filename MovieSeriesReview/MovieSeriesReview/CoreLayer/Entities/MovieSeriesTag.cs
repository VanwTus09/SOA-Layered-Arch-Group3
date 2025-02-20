using Azure;
using MovieSeriesReview.CoreLayer.Entities;


namespace MovieSeriesReview.CoreLayer.Entities
{
    public class MovieSeriesTag
    {
        public int Id { get; set; }
        public string MovieSeriesId { get; set; }
        public Movie Movie { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
