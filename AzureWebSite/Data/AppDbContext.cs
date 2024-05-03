using Microsoft.EntityFrameworkCore;

namespace AzureWebSite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Emp> Emps { get; set; }
    }
}
