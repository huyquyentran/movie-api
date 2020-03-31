using Microsoft.EntityFrameworkCore;

namespace MovieApp.Models
{

    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(movie =>
            {
                movie.ToTable("movies");
                movie.Property(m => m.Title).IsRequired();
            });

        }
    }
}