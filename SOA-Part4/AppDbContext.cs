using Azure;
using Microsoft.EntityFrameworkCore;
namespace MovieSeries.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieSeriesTag> MovieSeriesTags { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) :
       base(options)
        { }
        protected override void OnModelCreating(ModelBuilder
       modelBuilder)
        {
            modelBuilder.Entity<MovieSeriesTag>()
            .HasKey(mst => new { mst.MovieSeriesId, mst.TagId });
            modelBuilder.Entity<MovieSeriesTag>()
            .HasOne(mst => mst.Movie)
            .WithMany(m => m.MovieSeriesTags)
            .HasForeignKey(mst => mst.MovieSeriesId);
            modelBuilder.Entity<MovieSeriesTag>()
            .HasOne(mst => mst.Tag)
            .WithMany(t => t.MovieSeriesTags)
            .HasForeignKey(mst => mst.TagId);
        }
    }

    public class MovieSeriesTag
    {
         

        public int MovieSeriesId { get; set; } // ID của Movie
        public int TagId { get; set; } // ID của Tag

        public required Movie Movie { get; set; } // Navigation Property
        public required Tag Tag { get; set; } // Navigation Property
    }

    public class User
    {
    }

    public class Movie
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }
    }


    public class Review
    {
    }
}