using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }
        public DbSet<Book> Book { get; set; }
    }
}