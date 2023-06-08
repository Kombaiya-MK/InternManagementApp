using System.ComponentModel.DataAnnotations;

namespace TicketAPI.Models
{
    public class Ticket
    {
        public string? ticketNumber { get; set; }
        [Key]
        public int ticketId { get; set; }
        public string? ticketTitle { get; set; }
        public string? ticketDescription { get; set; }
        public DateTime issuedDate { get; set; }
        public string? ticketStatus { get; set; }
        public string? priority { get; set; }
        public int internId { get; set; }
    }
}
