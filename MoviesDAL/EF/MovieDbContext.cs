using Microsoft.EntityFrameworkCore;
using MoviesDAL.Models;

namespace MoviesDAL.EF
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = movies.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
