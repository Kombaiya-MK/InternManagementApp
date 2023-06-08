using Microsoft.EntityFrameworkCore;

namespace TicketAPI.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions opts) : base(opts)
        { 
        }

        public DbSet<Ticket> Tickets { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .Property(e => e.issuedDate)
                .HasColumnType("date");
        }
    }
}
