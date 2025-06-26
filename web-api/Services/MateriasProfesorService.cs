using universidad.Models;
using universidad.Repositories;
using universidad.Repositories.IRepositories;
using universidad.Services.IServices;
using universidad.Exceptions;
using universidad.Models.Dtos;

namespace universidad.Services
{
    public class MateriasProfesorService : IMateriaProfesorService
    {

        public readonly IMateriaProfesorRepository _Repository;

        public MateriasProfesorService(IMateriaProfesorRepository repository) { 
            this._Repository = repository; 
        }  
        
        public Task<IEnumerable<MateriaProfesorDto>> GetMateriasProfesoresAsync()
        {
            try
            {
               var res=this._Repository.GetMateriasProfesoresAsync();
                return res;
            }
            catch (Exception ex)
            {
                throw new MateriaProfesorException("Error al registrar la materia-profesor.", ex);
            }
        }



    }
}
