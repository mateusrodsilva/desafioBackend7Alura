using desafioBackend7Alura.AutoMapperProfiles;
using desafioBackend7Alura.Data.Context;
using desafioBackend7Alura.Data.Repositories;
using desafioBackend7Alura.Data.Repositories.Interfaces;
using desafioBackend7Alura.Services;
using desafioBackend7Alura.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var stringConexao = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(opts => opts.UseSqlServer(stringConexao));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Services

builder.Services.AddScoped<IDepoimentoService, DepoimentoService>();

#endregion

#region Repositories

builder.Services.AddScoped<IDepoimentoRepository, DepoimentoRepository>();

#endregion

#region AutoMapper Profiles

builder.Services.AddAutoMapper(typeof(DepoimentoProfile));

#endregion

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