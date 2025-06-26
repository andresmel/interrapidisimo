using universidad.Models;
using universidad.Models.Dtos;

namespace universidad.Services.IServices
{
    public interface IMateriaProfesorService
    {
        Task<IEnumerable<MateriaProfesorDto>> GetMateriasProfesoresAsync();
    }
}
