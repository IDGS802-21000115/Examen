﻿using Examen.Models;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connecionString = builder.Configuration.GetConnectionString("cadenaSQL");

//Agregamos la configuración para SQL
builder.Services.AddDbContext<TiendaCEl>(options =>
    options.UseSqlServer(connecionString)
);


//Definimos la nueva politica de CORS
builder.Services.AddCors(options =>
{

    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Activamos la nueva politica
app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();


app.Run();


