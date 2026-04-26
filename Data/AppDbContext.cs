using Microsoft.EntityFrameworkCore;
using LogPortalBackend.Models;

namespace LogPortalBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<log> Logs { get; set; }
    }
}