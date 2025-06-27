using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("policyangular", policy =>
    {
        policy.WithOrigins("http://localhost:4200") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("policyangular");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
