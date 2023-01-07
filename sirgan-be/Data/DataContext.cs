using Microsoft.EntityFrameworkCore;
using sirgan_be.Models;

namespace sirgan_be.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
            public DbSet<User> users { get; set; }
        public DbSet<Farm> farms { get; set; }

    }
}
