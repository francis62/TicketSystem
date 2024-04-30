using webapi.Repository.IRepositories;
using webapi.Service.IServices;
using webapi.Data.Models;

namespace webapi.Service.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IEventoService _eventoService;

        public TicketService(ITicketRepository ticketRepository, IEventoService eventoService)
        {
            _ticketRepository = ticketRepository;
            _eventoService = eventoService;
        }

        public async Task<int> GenerarTicketAsync(Ticket ticket)
        {

            List<DateTime> horasDisponibles = await _eventoService.GetHorasDisponibles(ticket.IdEvento);

            if (horasDisponibles.Contains(ticket.Hora))
            {
                return await _ticketRepository.CreateAsync(ticket);
            }
            else
            {
                throw new Exception(message: "Horario no disponible");
            }

        }

        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            return await _ticketRepository.GetAllAsync();
        }
    }
}
