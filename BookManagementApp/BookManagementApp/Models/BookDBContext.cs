
using Microsoft.EntityFrameworkCore;
namespace BookManagementApp.Models
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)   
        {

        }

        public DbSet<BookModel> BookDB { get; set; }
    }
}
