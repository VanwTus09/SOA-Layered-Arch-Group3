using Microsoft.EntityFrameworkCore;
using MovieSeriesReview.CoreLayer.Entities;

namespace MovieSeriesReview.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.MovieSeriesTags)
                .WithOne()
                .HasForeignKey(mst => mst.MovieId);
        }
    }
}
