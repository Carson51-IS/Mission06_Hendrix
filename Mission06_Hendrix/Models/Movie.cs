using System.ComponentModel.DataAnnotations;

namespace Mission06_Hendrix.Models
{
    /// <summary>
    /// Movie model: represents one movie record.
    /// Data Annotations ([Required], etc.) define validation rules + EF Core maps properties to DB columns.
    /// </summary>
    public class Movie
    {
        [Key]  // Primary key; EF expects this for the main identifier
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; } = string.Empty;

        [Required(ErrorMessage = "Rating is required")]
        public string Rating { get; set; } = string.Empty;

        // Nullable bool: optional. ? = can be null (user didn't select Yes/No)
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
        public string? Notes { get; set; }
    }
}
