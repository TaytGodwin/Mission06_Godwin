using Microsoft.EntityFrameworkCore;

namespace Mission06_Godwin.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base (options) { } // Constructor
        public DbSet<Movie> Movies { get; set; } // This makes a Movies table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData( // Seed data 
                    new Movie { MovieId = 1, Title = "The Dark Knight", Category = "Action", Year = 2008, Director = "Christopher Nolan", Rating = "PG-13" },
                    new Movie { MovieId = 2, Title = "Inception", Category = "Sci-Fi", Year = 2010, Director = "Christopher Nolan", Rating = "PG-13" },
                    new Movie { MovieId = 3, Title = "Interstellar", Category = "Sci-Fi", Year = 2014, Director = "Christopher Nolan", Rating = "PG-13" }
                );
        }
    }
}
