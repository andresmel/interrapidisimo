using universidad.Models;
using universidad.Models.Dtos;

namespace universidad.Services.IServices
{
    public interface IClaseService
    {
        Task<bool> PostClase(Clase clase);
        Task<ICollection<ClaseDto>> GetClasesById(int id);
    }
}
