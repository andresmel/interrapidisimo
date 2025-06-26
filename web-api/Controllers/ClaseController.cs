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
    public class ClaseController : ControllerBase
    {
        private readonly IClaseService _claseService;
        public ClaseController(IClaseService claseService)
        {
            _claseService = claseService;
        }
        [HttpPost("postClase")]
        public async Task<IActionResult> PostClase([FromBody] Clase clase)
        {
            if (clase == null)
            {
                return BadRequest("error en los datos");
            }

            responseApi api = new responseApi();
            try
            {
                var result = await _claseService.PostClase(clase);
                if (result)
                {
                    api.status = 200;
                    api.data = result;
                    api.mensaje = "Clase creada correctamente";
                    return Ok(api);
                }
                else
                {
                    api.status = 400;
                    api.data = null;
                    api.mensaje = "El estudiante ya tiene 3 clases asignadas";
                    return BadRequest(api);
                }
            }
            catch (ClasesException ex)
            {
                api.status = 400;
                api.data = null;
                api.mensaje = "error en la solicitud" + ex.Message;
                return BadRequest(api);
            }
            catch (Exception ex)
            {
                api.status = 500;
                api.data = null;
                api.mensaje = $"Error al crear la clase: {ex.Message}";
                return StatusCode(500, api);
            }
        }


        [HttpGet("getClases")]
        public async Task<IActionResult> GetClases(int id)
        {
            if (id == 0 )
            {
                return BadRequest("error en los datos");
            }

            responseApi api = new responseApi();
            try
            {
                var result = await _claseService.GetClasesById(id);
                if (result.Count()>0)
                {
                    api.status = 200;
                    api.data = result;
                    api.mensaje = "Clases Inscritas";
                }
                else
                {
                    api.status = 200;
                    api.data = null;
                    api.mensaje = "No hay clase inscrita";
                }
                return Ok(api);
            }
            catch (ClasesException ex)
            {
                api.status = 400;
                api.data = null;
                api.mensaje = "error en la solicitud" + ex.Message;
                return BadRequest(api);
            }
            catch (Exception ex)
            {
                api.status = 500;
                api.data = null;
                api.mensaje = $"Error Al cargar Clases: {ex.Message}";
                return StatusCode(500, api);
            }
        }

    }
}
