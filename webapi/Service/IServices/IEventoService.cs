using webapi.Models;

namespace webapi.Service.IServices
{
    public interface IEventoService
    {
        Task<IEnumerable<Evento>> ObtenerEventosAsync();
        Task<Evento> ObtenerEventoPorIdAsync(int id);
    }
}
