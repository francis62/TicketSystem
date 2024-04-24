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
    public interface ITicketRepository
    {
        Task GuardarTicketAsync(Ticket ticket);
    }
}
