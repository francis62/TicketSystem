using webapi.Models;

namespace webapi.Service.IServices
{
    public interface ITicketService
    {
        Task GenerarTicketAsync(Ticket ticket);
    }
}
