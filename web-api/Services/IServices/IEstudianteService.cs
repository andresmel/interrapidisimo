using universidad.Models;
using universidad.Models.Dtos;

namespace universidad.Services.IServices
{
    public interface IEstudianteService
    {
        Task<bool> PostEstudiantes(Estudiante estudiante);
        Task<EstudianteDto?> PostLogin(Estudiante estudiante);
    }
}
