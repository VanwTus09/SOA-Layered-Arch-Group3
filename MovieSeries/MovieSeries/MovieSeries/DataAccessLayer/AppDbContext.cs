using Microsoft.EntityFrameworkCore;
using MovieSeries.CoreLayer.Entities;

namespace MovieSeries.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<MovieSerie> MoviesSeries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieSeriesTag> MovieSeriesTags { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder
       modelBuilder)
        {
            // Định nghĩa khóa chính của bảng trung gian MovieSeriesTag
            modelBuilder.Entity<MovieSeriesTag>()
                .HasKey(mst => new { mst.MovieSeriesId, mst.TagId });

            // Thiết lập quan hệ giữa MovieSeriesTag và MovieSeries
            modelBuilder.Entity<MovieSeriesTag>()
                .HasOne(mst => mst.MovieSerie)
                .WithMany(m => m.MovieSeriesTags)
                .HasForeignKey(mst => mst.MovieSeriesId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ giữa MovieSeriesTag và Tag
            modelBuilder.Entity<MovieSeriesTag>()
                .HasOne(mst => mst.Tag)
                .WithMany(t => t.MovieSeriesTags)
                .HasForeignKey(mst => mst.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ giữa Review và User
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ giữa Review và MovieSeries
            modelBuilder.Entity<Review>()
                .HasOne(r => r.MovieSeries)
                .WithMany(m => m.Reviews)
                .HasForeignKey(r => r.MovieSeriesId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ giữa Rating và User
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Thiết lập quan hệ giữa Rating và MovieSeries
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.MovieSeries)
                .WithMany(m => m.Ratings)
                .HasForeignKey(r => r.MovieSeriesId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
