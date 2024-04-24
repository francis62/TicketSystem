using webapi.Repository.IRepositories;
using webapi.Models;
using webapi.Service.IServices;

namespace webapi.Service.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task GenerarTicketAsync(Ticket ticket)
        {
            await _ticketRepository.GuardarTicketAsync(ticket);
        }
    }
}
