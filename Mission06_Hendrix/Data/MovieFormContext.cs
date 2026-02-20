using Microsoft.EntityFrameworkCore;
using Mission06_Hendrix.Models;

namespace Mission06_Hendrix.Data
{
    /// <summary>
    /// DbContext: the bridge between our C# models and the database.
    /// DbSet&lt;Movie&gt; = one table. EF translates Add/SaveChanges to SQL INSERT.
    /// </summary>
    public class MovieFormContext : DbContext
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Joel Hilton DB: Movies.CategoryId is FK to Categories; optional.
            modelBuilder.Entity<Movie>(e =>
            {
                e.Property(m => m.Year).IsRequired(false);
                e.Property(m => m.Director).IsRequired(false);
                e.Property(m => m.Rating).IsRequired(false);
                e.Property(m => m.Edited).IsRequired(false);
                e.Property(m => m.CopiedToPlex).IsRequired(false);
                e.HasOne(m => m.Category)
                    .WithMany()
                    .HasForeignKey(m => m.CategoryId)
                    .IsRequired(false);
            });
        }
    }
}
