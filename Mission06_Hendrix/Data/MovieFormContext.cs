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
    }
}
