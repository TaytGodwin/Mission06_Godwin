using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Godwin.Models
{
    public class Movie
    {
        [Key] // MovieID is the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
            public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; } = null; // The question marks make it not required
            public Category? Category { get; set; }

        [Required(ErrorMessage = "Movie must have a title")]
            public string Title { get; set; } // Required in HTML too

        [Required]
        [Range(1880, int.MaxValue, ErrorMessage = "Year must be at least 1880.")]
            public int Year { get; set; } = 1880; // Required in HTML too
        
        public string? Director { get; set; }
        
        public string? Rating { get; set; }

        [Required(ErrorMessage = "Edited must be answered")]
            public bool Edited { get; set; } = false;

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "You must specify whether it has been copied to plex")]
        public bool CopiedToPlex { get; set; } = false;

        [MaxLength(25)] // Max length matches in database as well as on form
            public string? Notes { get; set; }
    }
}
