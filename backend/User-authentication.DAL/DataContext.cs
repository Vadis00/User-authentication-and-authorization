using Microsoft.EntityFrameworkCore;
using User_authentication.Common.Entities;

namespace User_authentication.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

    }
}
