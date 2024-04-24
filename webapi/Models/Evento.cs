namespace webapi.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public List<string> Horarios { get; set; }
    }
}
