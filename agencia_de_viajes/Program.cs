
using Application.Interfaces;
using Application.UseCase;
using Domain.Entities;
using Infrastructure.Client;
using Infrastructure.Command;
using Infrastructure.Data;
using Infrastructure.Persistence;
using Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<DestinosContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IPaisService, PaisService>();
builder.Services.AddScoped<IPaisCommand, PaisCommand>();
builder.Services.AddTransient<IPaisQuery, PaisQuery>();

builder.Services.AddScoped<IProvinciaService, ProvinciaService>();
builder.Services.AddScoped<IProvinciaCommand, ProvinciaCommand>();
builder.Services.AddTransient<IProvinciaQuery, ProvinciaQuery>();

builder.Services.AddScoped<ICiudadService, CiudadService>();
builder.Services.AddScoped<ICiudadCommand, CiudadCommand>();
builder.Services.AddTransient<ICiudadQuery, CiudadQuery>();

builder.Services.AddScoped<IViajeCiudadService, ViajeCiudadService>();
builder.Services.AddScoped<IViajeCiudadCommand, ViajeCiudadCommand>();
builder.Services.AddTransient<IViajeCiudadQuery, ViajeCiudadQuery>();

builder.Services.AddScoped<IEscalaService, EscalaService>();
builder.Services.AddScoped<IEscalaCommand, EscalaCommand>();
builder.Services.AddTransient<IEscalaQuery, EscalaQuery>();
builder.Services.AddScoped<IClientViaje, ClientViaje>();


//await PaisData.SeedPaises(); // HAY QUE EJCUTAR ESTA LINEA PARA TENER TODOS LOS PAISES,NO SE PUEDE DESCOMENTAR PQ NO DEJA HACER LA MIGRACION


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

