using Microsoft.EntityFrameworkCore;
using TicketAPI.Interfaces;
using TicketAPI.Models;

namespace TicketAPI.Services
{
    public class TicketRepo : IRepo<Ticket, int>
    {
        private readonly TicketContext _context;
        private readonly ILogger<TicketRepo> _logger;

        public TicketRepo(TicketContext context , ILogger<TicketRepo> logger) 
        { 
            _context = context;
            _logger = logger;
        }
        public async Task<Ticket?> Add(Ticket item)
        {
            try
            {
                _context.Tickets.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Ticket?> Delete(int key)
        {
            var ticket = await Get(key);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
                return ticket;
            }
            return null;
        }

        public async Task<Ticket?> Get(int key)
        {
            var ticket =  await _context.Tickets.FirstOrDefaultAsync(x => x.ticketId == key);
            return ticket;
        }

        public async Task<ICollection<Ticket>> GetAll()
        {
            var tickets = await _context.Tickets.ToListAsync();
            return tickets;
        }

        public async  Task<Ticket?> Update(Ticket item)
        {
            var ticket = await Get(item.ticketId);
            if (ticket != null)
            {
                ticket.ticketNumber = item.ticketNumber;
                ticket.ticketId = item.ticketId;
                ticket.ticketStatus = item.ticketStatus;
                ticket.ticketTitle = item.ticketTitle;
                ticket.ticketDescription = item.ticketDescription;
                ticket.issuedDate = item.issuedDate;
                await _context.SaveChangesAsync();
                return ticket;
            }
            return null;
        }
    }
}
