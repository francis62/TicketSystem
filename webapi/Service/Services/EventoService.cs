using webapi.Repository.IRepositories;
using webapi.Service.IServices;
using webapi.Data.Models;
using System.Net.Sockets;

namespace webapi.Service.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly ITicketService _ticketService;

        public EventoService(IEventoRepository eventoRepository, ITicketService ticketService)
        {
            _eventoRepository = eventoRepository;
            _ticketService = ticketService;
        }

        public async Task<List<DateTime>> GetHorasDisponibles(int idEvento)
        {
            var evento = await _eventoRepository.GetByIdAsync(idEvento);

            if (evento is null)
            {
                throw new Exception();
            }

            List<DateTime> horasDelEvento = GenerarHorasEntre(evento.HoraInicio, evento.HoraFinalizacion);
            List<DateTime> horasDisponibles = [];

            var tickets = await _ticketService.GetAllTicketsAsync();

            foreach (DateTime hora in horasDelEvento)
            {
                int ticketsPorHora = tickets.Count(ticket => ticket.Hora.TimeOfDay == hora.TimeOfDay);

                if (ticketsPorHora < evento.CantPersonasPorHora)
                {
                    horasDisponibles.Add(hora);
                }
            }

            return horasDisponibles;
        }

        private List<DateTime> GenerarHorasEntre(DateTime horaInicio, DateTime horaFin)
        {
            List<DateTime> horasEntre = new List<DateTime>();

            horasEntre.Add(horaInicio);

            DateTime horaActual = horaInicio;
            while (horaActual < horaFin)
            {
                horaActual = horaActual.AddHours(1);
                horasEntre.Add(horaActual);
            }

            return horasEntre;
        }
    }
}
