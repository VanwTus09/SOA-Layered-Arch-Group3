namespace MovieSeriesReview.CoreLayer.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; } = new List<MovieSeriesTag>();
    }
}
