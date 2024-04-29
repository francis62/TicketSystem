namespace webapi.Data.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinalizacion { get; set; }
        public int CantPersonasPorHora { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
