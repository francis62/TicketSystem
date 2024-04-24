using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Repository.IRepositories
{
    public interface IEventoRepository
    {
        Task<IEnumerable<Evento>> ObtenerEventosAsync();
        Task<Evento> ObtenerEventoPorIdAsync(int id);
    }
}
