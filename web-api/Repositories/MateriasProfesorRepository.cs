
using Microsoft.EntityFrameworkCore;
using universidad.Models;
using universidad.Models.Dtos;
using universidad.Repositories.IRepositories;
using universidad.UniversidadContext;

namespace universidad.Repositories
{
    public class MateriasProfesorRepository : IMateriaProfesorRepository
    {
        private readonly universidadContext _universidadContext;

        public MateriasProfesorRepository(universidadContext universidadContext)
        {
            this._universidadContext=universidadContext;
        }


        public async Task<IEnumerable<MateriaProfesorDto>> GetMateriasProfesoresAsync() {

            return await (
               from mp in _universidadContext.MateriasProfesores
               join m in _universidadContext.Materias on mp.IdMateria equals m.Id
               join p in _universidadContext.Profesores on mp.IdProfesor equals p.Id
               select new MateriaProfesorDto
               {
                   id = mp.Id,
                   materia = m.Nombre,
                   profesor = p.Nombre
               }
                ).ToListAsync();

               }
    }
}
