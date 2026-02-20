using System.ComponentModel.DataAnnotations;

namespace Mission06_Hendrix.Models
{
    /// <summary>
    /// Movie model: represents one movie record.
    /// Data Annotations ([Required], etc.) define validation rules + EF Core maps properties to DB columns.
    /// [Column("...")] maps our property names to the JoelHiltonMovieCollection.sqlite table column names.
    /// </summary>
    public class Movie
    {
        [Key]  // Primary key; EF expects this for the main identifier
        public int MovieId { get; set; }

        /// <summary>Optional. FK to Categories table (Joel Hilton DB); must be null or a valid CategoryId.</summary>
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Year is required")]
        [Range(1888, 2100, ErrorMessage = "Year must be 1888 or later (first movie year).")]
        public int? Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        /// <summary>Required: Was the movie edited? (Yes/No).</summary>
        [Required(ErrorMessage = "Edited (Yes/No) is required")]
        public bool? Edited { get; set; }

        /// <summary>Required: Was the movie copied to Plex? (Yes/No).</summary>
        [Required(ErrorMessage = "Copied to Plex (Yes/No) is required")]
        public bool? CopiedToPlex { get; set; }

        public string? LentTo { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
        public string? Notes { get; set; }
    }
}
