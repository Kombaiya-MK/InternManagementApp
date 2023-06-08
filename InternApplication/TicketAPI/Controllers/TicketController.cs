using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketAPI.Models;
using TicketAPI.Models.DTO;
using TicketAPI.Services;

namespace TicketAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[EnableCors(PolicyName = "MyCors")]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _service;

        public TicketController(TicketService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<Ticket>> GetTicketsonIntern(TicketDTO ticketDTO)
        {
            var ticket = await _service.GetTicketsOnIntern(ticketDTO.internId);
            if (ticket == null)
            {
                BadRequest("Invalid user id");
            }
            return Ok(ticket);
        }

        [HttpGet]
        public async Task<ActionResult<Ticket>> GetTickets(TicketDTO ticketDTO)
        {
            var tickets = await _service.GetTickets();
            if (tickets.Count < 1)
            {
                BadRequest("Invalid user id");
            }
            return Ok(tickets);
        }

        [HttpPost] 
        public async Task<ActionResult<Ticket>> AddTickets(TicketDTO ticketDTO)
        {
            var ticket = await _service.AddTicket(ticketDTO);
            if(ticket == null)
            {
                return BadRequest("Duplicate data can not be allowed!!!");
            }
            return Ok(ticket);
        }


        [HttpPut]
        public async Task<ActionResult<Ticket>> UpdateTickets(Ticket ticket)
        {
            var ticket1 = await _service.updateTicket(ticket);
            if (ticket1 == null)
            {
                return BadRequest("data updation failed!!!");
            }
            return Ok(ticket);
        }

        [HttpDelete]
        public async Task<ActionResult<Ticket>> DeleteTickets(Ticket ticket)
        {
            var ticket1 = await _service.DeleteTicket(ticket.ticketId);
            if (ticket1 == null)
            {
                return BadRequest("data deletion failed!!!");
            }
            return Ok(ticket);
        }
    }
}
