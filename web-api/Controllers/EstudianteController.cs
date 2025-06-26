using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using universidad.Exceptions;
using universidad.Models;
using universidad.Models.Dtos;
using universidad.Services.IServices;

namespace universidad.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _iestudianteService;

        public EstudianteController(IEstudianteService iestudianteService)
        {
            this._iestudianteService = iestudianteService;
        }

        [HttpPost("PostEstudiantes")]
        public async Task<IActionResult> PostEstudiantes([FromBody] Estudiante estudiante)
        {
            responseApi api = new responseApi();

            try
            {
                if (estudiante == null)
                {
                    api.status = 400;
                    api.data = null;
                    api.mensaje = "El estudiante no puede ser nulo";
                    return BadRequest(api);
                }

                var result = await this._iestudianteService.PostEstudiantes(estudiante);
                if (result)
                {
                    api.status = 200;
                    api.data = result;
                    api.mensaje = "Registro exitoso";
                    return Ok(api);
                }
                else
                {
                    api.status = 500;
                    api.data = result;
                    api.mensaje = "Error al guardar Registro";
                    return StatusCode(500, api);
                }
            
            }
            catch (EstudianteException ex)
            {
                api.status = 400;
                api.data = null;
                api.mensaje = "error en la solicitud" + ex.Message;
                return BadRequest(api);
            }
            catch (Exception ex)
            {
                // Cualquier otro error
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }


        [HttpPost("PostEstudianteLogin")]
        public async Task<IActionResult> PostEstudiantesLogin([FromBody] Estudiante estudiante)
        {
            responseApi api = new responseApi();

            try
            {
                if (estudiante == null)
                {
                    api.status = 400;
                    api.data = null;
                    api.mensaje = "El estudiante no puede ser nulo";
                    return BadRequest(api);
                }

                var result = await this._iestudianteService.PostLogin(estudiante);
                if (result != null)
                {
                    api.status = 200;
                    api.data = result;
                    api.mensaje = "Usuario Autenticado";
                    return Ok(api);
                }
                else
                {
                    api.status = 401;
                    api.data = null;
                    api.mensaje = "error en Usuario o contrasena";
                    return Unauthorized(api);
                }
            }
            catch (EstudianteException ex)
            {
                api.status = 400;
                api.data = null;
                api.mensaje = "error en la solicitud"+ex.Message;
                return BadRequest(api);
            }
            catch (Exception ex)
            {
                // Cualquier otro error
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }
    }
}
