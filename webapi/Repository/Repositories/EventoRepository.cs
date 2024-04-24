using webapi.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Repository.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly string eventosFilePath = "eventos.json";

        public async Task<IEnumerable<Evento>> ObtenerEventosAsync()
        {
            var eventosJson = await File.ReadAllTextAsync(eventosFilePath);
            var eventos = JsonSerializer.Deserialize<IEnumerable<Evento>>(eventosJson);
            return eventos;
        }
        public async Task<Evento> ObtenerEventoPorIdAsync(int id)
        {
            var eventos = await ObtenerEventosAsync();
            return eventos.FirstOrDefault(e => e.Id == id);
        }
    }
}
