using System;
using webapi.Data.Context;
using webapi.Data.Models;
using webapi.Repository.Repositories;

public class EventoRepository : GenericRepository<Evento>, IEventoRepository
{
    public EventoRepository(Context dbContext) : base(dbContext)
    {
    }
}

