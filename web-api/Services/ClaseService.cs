using universidad.Services.IServices;
using universidad.Models;
using universidad.Repositories.IRepositories;
using universidad.Exceptions;
using universidad.Models.Dtos;
namespace universidad.Services
{
    public class ClaseService : IClaseService
    {
        private readonly IClaseRepository _iclaseRepository;
        public ClaseService(IClaseRepository iclaseRepository)
        {
            this._iclaseRepository = iclaseRepository;
        }
        public async Task<bool> PostClase(Clase clase)
        {
            try
            {
                return await this._iclaseRepository.PostClase(clase);
            }
            catch (Exception ex)
            {
                throw new ClasesException($"error al crear la clase al estudiante: {ex.Message}", ex);
            }
        }

        public async Task<ICollection<ClaseDto>> GetClasesById(int id) {
            try
            {
                return await this._iclaseRepository.GetClasesById(id);
            }
            catch (Exception ex)
            {
                throw new ClasesException($"Error A listar clases: {ex.Message}", ex);
            }
        }

        public async Task<ICollection<ClaseDto>> GetClasesDiferentById(int id)
        {
            try
            {
                return await this._iclaseRepository.GetClasesDiferentById(id);
            }
            catch (Exception ex)
            {
                throw new ClasesException($"Error al listar clases diferentes: {ex.Message}", ex);
            }
        }

        public async Task<ICollection<claseMaDto>> GetClasesByIdAndMateria(int id)
        {
            try
            {
                return await this._iclaseRepository.GetClasesByIdAndMateria(id);
            }
            catch (Exception ex)
            {
                throw new ClasesException($"Error al listar clases por materia: {ex.Message}", ex);
            }
        }
    }
}
