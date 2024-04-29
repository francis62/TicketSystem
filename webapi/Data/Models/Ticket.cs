namespace webapi.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int IdEvento { get; set; }
        public string Email { get; set; }
        public Evento Evento { get; set; }
        public DateTime Hora { get; set; }
    }
}
