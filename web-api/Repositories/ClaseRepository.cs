using universidad.Repositories.IRepositories;
using universidad.Models;   
using universidad.UniversidadContext;
using Microsoft.EntityFrameworkCore;
using universidad.Models.Dtos;
namespace universidad.Repositories
{
    public class ClaseRepository : IClaseRepository
    {
        private readonly universidadContext _universidadcontext;

        public ClaseRepository(universidadContext universidadcontext)
        {
            this._universidadcontext = universidadcontext;
        }

        public async Task<bool> PostClase(Clase clase)
        {

        
            var materiaProfesor = await _universidadcontext.MateriasProfesores
                .FirstOrDefaultAsync(mp => mp.Id == clase.IdMateriasProfesores);

            if (materiaProfesor == null)
            {
                return false; 
            }

            var idProfesorNuevo = materiaProfesor.IdProfesor;

            
            var yaTieneConEseProfesor = await (
                from c in _universidadcontext.Clases
                join mp in _universidadcontext.MateriasProfesores
                    on c.IdMateriasProfesores equals mp.Id
                where c.IdEstudiante == clase.IdEstudiante && mp.IdProfesor == idProfesorNuevo
                select c
            ).AnyAsync();

            if (yaTieneConEseProfesor)
            {
                return false;
            }

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
            }).ToListAsync();

            return resultado;
        }


        public async Task<ICollection<ClaseDto>> GetClasesDiferentById(int id)
        {
            var resultado = await (
            from c in _universidadcontext.Clases
            join e in _universidadcontext.Estudiantes on c.IdEstudiante equals e.Id
            join mp in _universidadcontext.MateriasProfesores on c.IdMateriasProfesores equals mp.Id
            join m in _universidadcontext.Materias on mp.IdMateria equals m.Id
            join p in _universidadcontext.Profesores on mp.IdProfesor equals p.Id
            where c.IdEstudiante != id
            orderby c.IdEstudiante ascending
            select new ClaseDto
            {
                IdClase = c.IdClase,
                Estudiante = e.Nombre,
                Materia = m.Nombre,
                Profesor = p.Nombre
            }).ToListAsync();
            return resultado;
        }

        public async Task<ICollection<claseMaDto>> GetClasesByIdAndMateria(int id)
        {
            var resultado = await (
            from c1 in _universidadcontext.Clases
            where c1.IdEstudiante == id
            join c2 in _universidadcontext.Clases on c1.IdMateriasProfesores equals c2.IdMateriasProfesores
            where c2.IdEstudiante != id
            join e2 in _universidadcontext.Estudiantes on c2.IdEstudiante equals e2.Id
            join mp in _universidadcontext.MateriasProfesores on c2.IdMateriasProfesores equals mp.Id
            join m in _universidadcontext.Materias on mp.IdMateria equals m.Id
            join p in _universidadcontext.Profesores on mp.IdProfesor equals p.Id
            orderby m.Nombre, e2.Nombre
            select new claseMaDto
            {
               id_clase = c2.IdClase,
               id_estudiante = e2.Id,
               estudiante = e2.Nombre,
               materia = m.Nombre,
               profesor = p.Nombre
            }
            ).ToListAsync();
            return resultado;
        }
    }
}