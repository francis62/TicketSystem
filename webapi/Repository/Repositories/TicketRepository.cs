using webapi.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Repository.IRepositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly string ticketsFilePath = "tickets.json";

        public async Task GuardarTicketAsync(Ticket ticket)
        {
            var tickets = new List<Ticket>();

            if (File.Exists(ticketsFilePath))
            {
                var ticketsJson = await File.ReadAllTextAsync(ticketsFilePath);
                tickets = JsonSerializer.Deserialize<List<Ticket>>(ticketsJson);
            }

            tickets.Add(ticket);
            var newTicketsJson = JsonSerializer.Serialize(tickets);
            await File.WriteAllTextAsync(ticketsFilePath, newTicketsJson);
        }
    }
}
