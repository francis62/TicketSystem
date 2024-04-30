using webapi.Repository.IRepositories;
using webapi.Repository.Repositories;
using Microsoft.Extensions.Configuration;
using webapi;
using webapi.Service.IServices;
using webapi.Service.Services;
using webapi.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.Configure<ConfiguracionCorreo>(configuration.GetSection("Correo"));
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TicketConnection")));


builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();


builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<ICorreoService, CorreoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
