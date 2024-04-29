using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using webapi.Data.Models;
using webapi.Service.IServices;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        private readonly ITicketService _ticketService;

        public EventosController(IEventoService eventoService, ITicketService ticketService)
        {
            _eventoService = eventoService;
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IEnumerable<Evento>> GetEventos()
        {
            return await _eventoService.GetEventos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await _eventoService.GetEvento(id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        [HttpGet("HorasDisponibles/{id}")]
        public async Task<IEnumerable<DateTime>> GetHorasDisponibles(int id)
        {
            var horasDisponibles = await _eventoService.GetHorasDisponibles(id);

            return horasDisponibles;
        }

        [HttpPost("reservar")]
        public async Task<IActionResult> ReservarEntrada(Ticket ticket)
        {
            try
            {
                await _ticketService.GenerarTicketAsync(ticket);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al procesar la reserva: {ex.Message}");
            }
        }
    }
}
