namespace TicketAPI.Models.DTO
{
    public class TicketDTO
    {
        public string? ticketTitle { get; set; }
        public string? ticketDescription { get; set; }
        public string? priority { get; set;}
        public int internId{ get; set; }
    }
}
