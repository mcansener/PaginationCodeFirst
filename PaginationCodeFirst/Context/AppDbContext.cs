using Microsoft.EntityFrameworkCore;
using PaginationCodeFirst.Models;

namespace PaginationCodeFirst.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
