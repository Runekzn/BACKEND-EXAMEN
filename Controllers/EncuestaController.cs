
using Microsoft.AspNetCore.Mvc;
using EXAMEN.Models;
using EXAMEN.Services.EncuestaService;


namespace EXAMEN.Controllers
{
    
    [Route("api/encuesta")]
    [ApiController]
    public class EncuestaController : ControllerBase
    {
        private readonly IEncuestaService _encuestaService;
        public EncuestaController(IEncuestaService encuestaService)
        {
            _encuestaService = encuestaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Encuesta>>> GetAllEncuesta()
       {
            return await _encuestaService.GetAllEncuesta();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Encuesta>> GetSingleEncuesta(int id)
        {
            var result = await _encuestaService.GetSingleEncuesta(id);
            if(result == null)
            {
                return NotFound("Encuesta no encontrada");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Encuesta>> AddEncuesta(Encuesta encuesta)
        {
            var result = await _encuestaService.AddEncuesta(encuesta);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Encuesta>>> UpdateEncuesta( Encuesta request)
        {
            var result = await _encuestaService.UpdateEncuesta(request.ENCUESTA_ID, request);
            if (result is null)
                return NotFound("Encuesta no se encuentra");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Encuesta>>> DeleteEncuesta(int id)
        {
            var result = await _encuestaService.DeleteEncuesta(id);
            if (result is null)
                return NotFound("Encuesta no encontrada.");

            return Ok(result);
        }
    }
}
