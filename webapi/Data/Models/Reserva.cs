namespace webapi.Data.Models
{
    public class Reserva
    {
        public int EventoId { get; set; }
        public DateTime FechaSeleccionada { get; set; }
        public string HorarioSeleccionado { get; set; }
        public string Email { get; set; }
    }
}
