using webapi.Repository.IRepositories;
using webapi.Models;
using webapi.Service.IServices;

namespace webapi.Service.Services
{
    public class ReservaService : IReservaService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ICorreoService _correoService;

        public ReservaService(ITicketRepository ticketRepository, ICorreoService correoService)
        {
            _ticketRepository = ticketRepository;
            _correoService = correoService;
        }

        public async Task ConfirmarReservaAsync(Reserva reserva)
        {
            Ticket ticket = new Ticket
            {
                EventoId = reserva.EventoId,
                FechaReserva = DateTime.Now,
                Email = reserva.Email
            };

            await _ticketRepository.GuardarTicketAsync(ticket);

            await _correoService.EnviarCorreoAsync(reserva.Email, "Confirmación de reserva", "Adjunto encontrará su código QR para ingresar al evento.");
        }
    }
}
