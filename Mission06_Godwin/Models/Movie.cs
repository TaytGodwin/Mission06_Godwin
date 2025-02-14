using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Godwin.Models
{
    public class Movie
    {
        [Key] // MovieID is the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; } // Required in HTML too
        [Required]
        public string Category { get; set; } // Required in HTML too
        [Required]
        public int Year { get; set; } // Required in HTML too
        [Required]
        public string Director { get; set; } // Required in HTML too
        [Required]
        public string Rating { get; set; } // Required in HTML too
        public bool? Edited { get; set; } // The question marks make it not required
        public string? LentTo { get; set; }
        [MaxLength(25)] // Max length matches in database as well as on form
        public string? Notes { get; set; }
    }
}
