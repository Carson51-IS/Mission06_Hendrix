using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Hendrix.Models
{
    /// <summary>
    /// Category/Genre for movies. Joel Hilton DB has a Categories table; Movies.CategoryId references this.
    /// </summary>
    [Table("Categories")]
    public class Category
    {
        public int CategoryId { get; set; }

        /// <summary>Display name; Joel Hilton DB column is CategoryName.</summary>
        public string CategoryName { get; set; } = string.Empty;
    }
}
