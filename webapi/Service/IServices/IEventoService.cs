using webapi.Data.Models;

namespace webapi.Service.IServices
{
    public interface IEventoService
    {
        Task<List<DateTime>> GetHorasDisponibles(int idEvento);
    }
}
