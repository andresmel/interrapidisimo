using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using universidad.Exceptions;
using universidad.Models.Dtos;
using universidad.Services.IServices;


namespace universidad.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MateriaProfesorController : ControllerBase
    {
        public readonly IMateriaProfesorService _imateriaProfesorService;

        public MateriaProfesorController(IMateriaProfesorService imateriaProfesorService)
        {
            this._imateriaProfesorService = imateriaProfesorService;
        }

        [HttpGet("MateriaProfesores")]
        public async Task<IActionResult> GetMateriasProfesores()
        {
            responseApi api = new responseApi();
            try
            {
             
                var res = await this._imateriaProfesorService.GetMateriasProfesoresAsync();
                if (res.Any())
                {
                    api.status = 200;
                    api.data = res;
                    api.mensaje = "success";
                  
                }
                else
                {
                    api.status = 200;
                    api.data = res;
                    api.mensaje = "No content ";
                }
                return Ok(api);
            }
            catch (MateriaProfesorException ex)
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
    }
}
