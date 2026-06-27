using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Datos;

namespace TaskManager.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {


        private readonly ContextoBaseDatos _contexto;


        public LogsController(ContextoBaseDatos contexto)
        {
            _contexto = contexto;
        }





        [HttpGet]
        public async Task<IActionResult> ObtenerLogs()
        {

            var logs = await _contexto.LogTareas
                .Include(x => x.Tarea)
                .OrderByDescending(x => x.Fecha)
                .Select(x => new
                {

                    id = x.LogId,

                    tareaId = x.TareaId,

                    tarea = x.Tarea.Titulo,

                    usuario = x.Usuario,

                    accion = x.Accion,

                    fecha = x.Fecha,

                    detalle = x.Detalle


                })
                .ToListAsync();



            return Ok(logs);

        }


    }

}