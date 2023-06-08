using TicketAPI.Interfaces;
using TicketAPI.Models;
using TicketAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace TicketAPI.Services
{
    public class TicketService
    {
        private readonly IRepo<Ticket, int> _repo;

        public TicketService(IRepo<Ticket , int> repo) {
            _repo = repo; 
        }

        public async Task<Ticket?> AddTicket(TicketDTO ticket)
        {
            Ticket ticket1 = new Ticket();
            ticket1.ticketTitle = ticket.ticketTitle;
            ticket1.ticketDescription = ticket.ticketDescription;
            ticket1.internId = ticket.internId;
            ticket1.priority = ticket.priority;
            ticket1.ticketNumber ="INTERN" + ticket.internId.ToString() + "TNO" + ticket1.ticketId.ToString();
            ticket1.issuedDate = DateTime.Now;
            ticket1.ticketStatus = "New";
            var ticket2 = await _repo.Add(ticket1);
            return ticket2;
        }

        public async Task<ICollection<Ticket>> GetTickets()
        {
            return (await _repo.GetAll());
        }
        public async Task<Ticket?> updateTicket(Ticket ticket)
        {
            return await _repo.Update(ticket);
        }

        public async Task<Ticket?> DeleteTicket(int key)
        {
            return await _repo.Delete(key);
        }

        public async Task<Ticket?> GetTicket(int key)
        {
            return await _repo.Get(key);
        }

        public async Task<ICollection<Ticket>> GetTicketsOnIntern(int key)
        {
            return await GetTickets();
        }
    }
}
