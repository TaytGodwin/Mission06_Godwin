using Microsoft.EntityFrameworkCore;

namespace Mission06_Godwin.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base (options) { } // Constructor
        public DbSet<Movie> Movies { get; set; } // This makes a Movies table
        public DbSet<Category> Categories { get; set; } // This makes a Categories table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData( // Seed data in Categories
                    new Category { CategoryId = 1, CategoryName = "Miscellaneous" },
                    new Category { CategoryId = 2, CategoryName = "Drama" },
                    new Category { CategoryId = 3, CategoryName = "Television" },
                    new Category { CategoryId = 4, CategoryName = "Horro/Suspense" },
                    new Category { CategoryId = 5, CategoryName = "Comedy" },
                    new Category { CategoryId = 6, CategoryName = "Family" },
                    new Category { CategoryId = 7, CategoryName = "Action/Adventure" },
                    new Category { CategoryId = 8, CategoryName = "VHS" }
                );
            modelBuilder.Entity<Movie>().HasData( // Seed data in Movies
                    new Movie { MovieId = 1, Title = "The Dark Knight", CategoryId = 7, Year = 2008, Director = "Christopher Nolan", Rating = "PG-13" },
                    new Movie { MovieId = 2, Title = "Inception", CategoryId = 7, Year = 2010, Director = "Christopher Nolan", Rating = "PG-13" },
                    new Movie { MovieId = 3, Title = "Interstellar", CategoryId = 7, Year = 2014, Director = "Christopher Nolan", Rating = "PG-13" }
                );

        }

    }
}
