using Microsoft.EntityFrameworkCore;

namespace UserAPI.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Intern>? interns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Intern>().Property(i => i.Id).ValueGeneratedNever();
        }
    }
}
