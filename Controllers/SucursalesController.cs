using Microsoft.AspNetCore.Mvc;
using EXAMEN.Models;
using EXAMEN.Services.SucursalesService;
using Microsoft.AspNetCore.Cors;

namespace EXAMEN.Controllers
{
    [Route("api/sucursales")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly ISucursalesService _sucursalesService;

  
        public SucursalesController(ISucursalesService sucursalesService)
        {
            _sucursalesService = sucursalesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sucursal>>> GetAllSucursales()
        {
            return await _sucursalesService.GetAllSucursales();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sucursal>> GetSingleSucursal(int id)
        {
            var result = await _sucursalesService.GetSingleSucurales(id);
            if (result == null)
            {
                return NotFound("Sucursal no encontrada");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Sucursal>> AddSucural(Sucursal sucursal)
        {
            var result = await _sucursalesService.AddSucursales(sucursal);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Sucursal>>> UpdateSucursal( Sucursal request)
        {
            var result = await _sucursalesService.UpdateSucursales(request.SUCURSAL_ID, request);
            if (result is null)
                return NotFound("Sucural no se encontro");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Sucursal>>> DeleteSucursales(int id)
        {
            var result = await _sucursalesService.DeleteSucursales(id);
            if (result is null)
                return NotFound("Sucursal no encontrada");
            return Ok(result);
        }
    }
}
