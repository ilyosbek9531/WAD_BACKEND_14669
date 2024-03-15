using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_14669.Models;

namespace WAD_BACKEND_14669.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
