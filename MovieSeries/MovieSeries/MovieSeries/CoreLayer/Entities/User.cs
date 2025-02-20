namespace MovieSeries.CoreLayer.Entities
{
    public class User
    {
        public int Id { get; set; } // user_id
        public string Username { get; set; } // username
        public string Email { get; set; } // email
        public DateTime CreatedAt { get; set; } = DateTime.Now; // created_at

        // Navigation properties
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
