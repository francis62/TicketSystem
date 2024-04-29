using webapi.Data.Models;

namespace webapi.Service.IServices
{
    public interface IReservaService
    {
        Task ConfirmarReservaAsync(Reserva reserva);
    }
}
