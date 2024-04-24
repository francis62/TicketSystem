using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using webapi.Models;
using webapi.Service.IServices;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        private readonly IReservaService _reservaService;
        private readonly string ticketsFilePath = "tickets.json";

        public EventosController(IEventoService eventoService, IReservaService reservaService)
        {
            _eventoService = eventoService;
            _reservaService = reservaService;
        }

        [HttpGet]
        public async Task<IEnumerable<Evento>> GetEventos()
        {
            return await _eventoService.ObtenerEventosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await _eventoService.ObtenerEventoPorIdAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        [HttpPost("reservar")]
        public async Task<IActionResult> ReservarEntrada([FromBody] Reserva reserva)
        {
            try
            {
                await GuardarTicketAsync(reserva);
                return Ok("Reserva confirmada. Se generó el ticket correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al procesar la reserva: {ex.Message}");
            }
        }

        private async Task GuardarTicketAsync(Reserva reserva)
        {
            if (!System.IO.File.Exists(ticketsFilePath))
            {
                var tickets = new List<Reserva> { reserva };
                var json = JsonSerializer.Serialize(tickets);
                await System.IO.File.WriteAllTextAsync(ticketsFilePath, json);
            }
            else
            {
                var existingJson = await System.IO.File.ReadAllTextAsync(ticketsFilePath);
                var tickets = JsonSerializer.Deserialize<List<Reserva>>(existingJson);
                tickets.Add(reserva);
                var updatedJson = JsonSerializer.Serialize(tickets);
                await System.IO.File.WriteAllTextAsync(ticketsFilePath, updatedJson);
            }
        }
    }
}
