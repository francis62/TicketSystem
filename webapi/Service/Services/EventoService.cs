using webapi.Repository.IRepositories;
using webapi.Models;
using webapi.Service.IServices;

namespace webapi.Service.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<IEnumerable<Evento>> ObtenerEventosAsync()
        {
            return await _eventoRepository.ObtenerEventosAsync();
        }

        public async Task<Evento> ObtenerEventoPorIdAsync(int id)
        {
            return await _eventoRepository.ObtenerEventoPorIdAsync(id);
        }
    }
}
