using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Datos;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogosController : ControllerBase
    {

        private readonly ContextoBaseDatos _contexto;


        public CatalogosController(ContextoBaseDatos contexto)
        {
            _contexto = contexto;
        }




        [HttpGet("Estados")]
        public async Task<IActionResult> ObtenerEstados()
        {

            var estados = await _contexto.Estados
                .Select(x => new
                {
                    id = x.EstadoId,
                    nombre = x.Nombre
                })
                .ToListAsync();


            return Ok(estados);
        }



        [HttpGet("Prioridades")]
        public async Task<IActionResult> ObtenerPrioridades()
        {

            var prioridades = await _contexto.Prioridades
                .Select(x => new
                {
                    id = x.PrioridadId,
                    nombre = x.Nombre
                })
                .ToListAsync();


            return Ok(prioridades);
        }

    }
}