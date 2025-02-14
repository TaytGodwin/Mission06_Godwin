using Microsoft.EntityFrameworkCore;

namespace Mission06_Godwin.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base (options) { } // Constructor
        public DbSet<Movie> Movies { get; set; } // This makes a Movies table
    }
}
