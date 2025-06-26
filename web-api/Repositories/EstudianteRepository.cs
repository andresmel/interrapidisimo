using Microsoft.EntityFrameworkCore;
using universidad.Models;
using universidad.Models.Dtos;
using universidad.Repositories.IRepositories;
using universidad.UniversidadContext;

namespace universidad.Repositories
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly universidadContext _universidadContext;

        public EstudianteRepository(universidadContext universidadContext)
        {
            this._universidadContext = universidadContext;
        }

        public async Task<int> PostEstudiantes(Estudiante estudiante)
        {
            await _universidadContext.Estudiantes.AddAsync(estudiante);
            var res =await this._universidadContext.SaveChangesAsync();
            return res;
         
        }

        public async Task<Estudiante?> PostLogin(Estudiante estudiante)
        {
            var res = await this._universidadContext.Estudiantes
                .Where(c => c.Email == estudiante.Email)
                .FirstOrDefaultAsync();
            if(res == null)
                return null;
            
            if (!BCrypt.Net.BCrypt.Verify(estudiante.Password, res.Password))
                return null;
            
            return  res;
        }
    }
}
