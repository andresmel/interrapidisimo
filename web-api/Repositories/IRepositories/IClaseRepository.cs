using universidad.Models;
using universidad.Models.Dtos;

namespace universidad.Repositories.IRepositories
{
    public interface IClaseRepository
    {
        Task<bool> PostClase(Clase clase);
        Task<ICollection<ClaseDto>> GetClasesById(int id);

        Task<ICollection<ClaseDto>> GetClasesDiferentById(int id);

        Task<ICollection<claseMaDto>> GetClasesByIdAndMateria(int id);
    }
}
