using webapi.Data.Models;

namespace webapi.Service.IServices
{
    public interface IEventoService
    {
        Task<List<DateTime>> GetHorasDisponibles(int idEvento);
        Task<List<Evento>> GetEventos();
        Task<Evento?> GetEvento(int idEvento);
    }
}
