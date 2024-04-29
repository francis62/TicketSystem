using System.Text.Json;
using webapi.Data.Context;
using webapi.Data.Models;
using webapi.Repository.Repositories;

namespace webapi.Repository.IRepositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(Context dbContext) : base(dbContext) { }
    }
}
