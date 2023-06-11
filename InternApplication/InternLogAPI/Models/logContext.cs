using Microsoft.EntityFrameworkCore;

namespace InternLogAPI.Models
{
    public class logContext : DbContext
    {
        public logContext(DbContextOptions options):base(options) {
        }

        public DbSet<Log> logs { get; set; }

    }
}
