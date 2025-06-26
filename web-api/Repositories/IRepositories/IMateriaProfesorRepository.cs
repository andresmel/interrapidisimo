using universidad.Models;
using universidad.Models.Dtos;

namespace universidad.Repositories.IRepositories
{
    public interface IMateriaProfesorRepository
    {
       Task<IEnumerable<MateriaProfesorDto>> GetMateriasProfesoresAsync();
    }
}
