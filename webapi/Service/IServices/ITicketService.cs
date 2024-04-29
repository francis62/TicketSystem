using webapi.Data.Models;

namespace webapi.Service.IServices
{
    public interface ITicketService
    {
        Task GenerarTicketAsync(Ticket ticket);
        Task<List<Ticket>> GetAllTicketsAsync();
    }
}
