using EXAMEN.Models;
using EXAMEN.Services.EncuestadoService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EXAMEN.Controllers
{
 
    [Route("api/encuestado")]
    [ApiController]
    public class EncuestadoController : ControllerBase
    {
        private readonly IEncuestadoService _encuestadoService;
        public EncuestadoController(IEncuestadoService encuestadoService)
        {
            _encuestadoService = encuestadoService;
        }

      
        [HttpGet]
        public async Task<ActionResult<List<Encuestado2>>> GetAllEncuestado()
        {
            return await _encuestadoService.GetAllEncuestados();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Encuestado2>> GetSingleEncuestados(int id)
        {
            var result = await _encuestadoService.GetSingleEncuestados(id);
            if(result == null)
            {
                return NotFound("Encuestado no encontrado");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Encuestado2>> AddEncuestado(Encuestado2 encuestado)
        {
            var result = await _encuestadoService.AddEncuestado(encuestado);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Encuestado2>>> UpdateEncuestado(Encuestado2 request)
        {

           // var encue = await _encuestadoService.GetSingleEncuestados(request.ID_ENCUESTADO);
            var result = await _encuestadoService.UpdateEncuestado(request.ID_ENCUESTADO, request);
            if (result is null)
                return NotFound("Encuestado no encontrado.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Encuestado2>>> DeleteEncuestado(int id)
        {
            var result = await _encuestadoService.DeleteEncuestado(id);
            if (result is null)
                return NotFound("Encuestado no encontrado.");
            return Ok(result);
        }
    }
}
