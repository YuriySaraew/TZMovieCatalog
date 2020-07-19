using Microsoft.EntityFrameworkCore;
namespace MovCat.Models
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieUser> MovieUsers { get; set; }
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) => Database.EnsureCreated();
    }
}
