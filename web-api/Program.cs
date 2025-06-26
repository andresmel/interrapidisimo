using Microsoft.EntityFrameworkCore;
using universidad.Repositories;
using universidad.Repositories.IRepositories;
using universidad.Services;
using universidad.Services.IServices;
using universidad.UniversidadContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Leer cadena desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("universidad");

builder.Services.AddDbContext<universidadContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IMateriaProfesorRepository, MateriasProfesorRepository>();
builder.Services.AddScoped<IMateriaProfesorService, MateriasProfesorService>();
builder.Services.AddScoped<IEstudianteRepository, EstudianteRepository>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IClaseRepository, ClaseRepository>();
builder.Services.AddScoped<IClaseService, ClaseService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
