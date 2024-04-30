using webapi.Data.Models;

namespace webapi.Service.IServices
{
    public interface ITicketService
    {
        Task<int> GenerarTicketAsync(Ticket ticket);
        Task<List<Ticket>> GetAllTicketsAsync();
    }
}
