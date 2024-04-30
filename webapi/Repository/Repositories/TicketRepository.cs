using webapi.Data.Context;
using webapi.Data.Models;
using webapi.Repository.Repositories;

namespace webapi.Repository.IRepositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(Context dbContext) : base(dbContext) { }

        public override async Task<int> CreateAsync(Ticket ticket)
        {
            await _dbSet.AddAsync(ticket);
            await _context.SaveChangesAsync();

            await _context.Entry(ticket).ReloadAsync();

            return ticket.Id;
        }
    }
}
