namespace MovieSeries.CoreLayer.Entities
{
    public class Tag
    {
        public int Id { get; set; } // tag_id
        public string Name { get; set; } // tag_name

        // Navigation properties
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; } = new List<MovieSeriesTag>();
    }
}
