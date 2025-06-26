using universidad.Models;
using universidad.Models.Dtos;

namespace universidad.Repositories.IRepositories
{
    public interface IEstudianteRepository
    {
        Task<int> PostEstudiantes(Estudiante estudiante);
        Task<Estudiante?> PostLogin(Estudiante estudiante);
    }
}
