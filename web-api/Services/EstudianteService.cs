using universidad.Exceptions;
using universidad.Models;
using universidad.Repositories.IRepositories;
using universidad.Services.IServices;
using BCrypt.Net;
using universidad.Models.Dtos;

namespace universidad.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _iestudianteRepository;

        public EstudianteService(IEstudianteRepository repository)
        {
            this._iestudianteRepository = repository;
        }

        public async Task<bool> PostEstudiantes(Estudiante estudiante)
        {
            try
            {
                estudiante.Password = BCrypt.Net.BCrypt.HashPassword(estudiante.Password);
                var res = await this._iestudianteRepository.PostEstudiantes(estudiante);
                if (res > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new EstudianteException("Error al registrar el estudiante.", ex);
            }
        }

        public async Task<EstudianteDto?> PostLogin(Estudiante estudiante)
        {
            try
            {
                var res = await this._iestudianteRepository.PostLogin(estudiante);
                if (res == null)
                    return null;

                var estudianteDto = new EstudianteDto();
                estudianteDto.Id = res.Id;
                estudianteDto.Nombre = res.Nombre;
                estudianteDto.Email = res.Email;

                return estudianteDto;
            }
            catch (Exception ex)
            {
                throw new EstudianteException("Error al iniciar sesión.", ex);
            }
        }
    }
}
