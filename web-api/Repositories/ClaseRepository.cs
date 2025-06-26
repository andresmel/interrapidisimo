using universidad.Repositories.IRepositories;
using universidad.Models;   
using universidad.UniversidadContext;
using Microsoft.EntityFrameworkCore;
using universidad.Models.Dtos;
namespace universidad.Repositories
{
    public class ClaseRepository :IClaseRepository
    {
        private readonly universidadContext _universidadcontext;

        public ClaseRepository(universidadContext universidadcontext)
        {
            this._universidadcontext = universidadcontext;
        }

        public async Task<bool> PostClase(Clase clase)
        {
          
            var res = await _universidadcontext.Clases.CountAsync(c => c.IdEstudiante == clase.IdEstudiante);
            if (res >= 3)
            {
                return false;
            }
            await _universidadcontext.Clases.AddAsync(clase);
            return await _universidadcontext.SaveChangesAsync() > 0;
        }

        public async Task<ICollection<ClaseDto>> GetClasesById(int id) 
        {
            var resultado = await (
            from c in _universidadcontext.Clases
            join e in _universidadcontext.Estudiantes on c.IdEstudiante equals e.Id
            join mp in _universidadcontext.MateriasProfesores on c.IdMateriasProfesores equals mp.Id
            join m in _universidadcontext.Materias on mp.IdMateria equals m.Id
            join p in _universidadcontext.Profesores on mp.IdProfesor equals p.Id
            where c.IdEstudiante == id
            select new ClaseDto
        {
            IdClase = c.IdClase,
            Estudiante = e.Nombre,
            Materia = m.Nombre,
            Profesor = p.Nombre
        }
    ).ToListAsync();

            return resultado;
        }
         
    }
}
