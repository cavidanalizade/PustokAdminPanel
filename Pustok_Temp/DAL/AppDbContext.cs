using Microsoft.EntityFrameworkCore;
using Pustok_Temp.Models;


namespace Pustok_Temp.DAL
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Book_Img> bookimages { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Slider> sliders { get; set; }

    }
}
