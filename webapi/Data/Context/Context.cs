using Microsoft.EntityFrameworkCore;
using webapi.Data.Models;

namespace webapi.Data.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>().ToTable("Evento");

            modelBuilder.Entity<Evento>()
                .Property(e => e.Fecha)
                .HasColumnType("date");

            modelBuilder.Entity<Evento>()
                .Property(e => e.HoraInicio)
                .HasColumnType("time");

            modelBuilder.Entity<Evento>()
                .Property(e => e.HoraFinalizacion)
                .HasColumnType("time");

            modelBuilder.Entity<Ticket>().ToTable("Ticket");

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.Tickets)
                .WithOne(t => t.Evento)
                .HasForeignKey(t => t.IdEvento);
        }
    }
}
