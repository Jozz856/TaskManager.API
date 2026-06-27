using Microsoft.AspNetCore.Mvc;
using TaskManager.API.DTOs;
using TaskManager.API.Modelos;
using TaskManager.API.Services;
using Microsoft.AspNetCore.Authorization;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {

        private readonly ITareaService _service;


        public TareasController(ITareaService service)
        {
            _service = service;
        }



    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TareaRespuestaDto>>> ObtenerTareas()
        {

            var tareas = await _service.ObtenerTodas();



            var respuesta = tareas.Select(x => new TareaRespuestaDto
            {

                Id = x.Id,

                Titulo = x.Titulo,

                Descripcion = x.Descripcion,

                Estado = x.Estado.Nombre,

                Prioridad = x.Prioridad.Nombre,

                FechaCreacion = x.FechaCreacion,

                FechaActualizacion = x.FechaActualizacion


            });



            return Ok(respuesta);

        }






        [HttpGet("{id}")]
        public async Task<ActionResult<TareaRespuestaDto>> ObtenerTarea(int id)
        {

            var tarea = await _service.ObtenerPorId(id);



            if (tarea == null)
            {
                return NotFound(new
                {
                    mensaje = "No existe la tarea"
                });
            }



            var respuesta = new TareaRespuestaDto
            {

                Id = tarea.Id,

                Titulo = tarea.Titulo,

                Descripcion = tarea.Descripcion,

                Estado = tarea.Estado.Nombre,

                Prioridad = tarea.Prioridad.Nombre,

                FechaCreacion = tarea.FechaCreacion,

                FechaActualizacion = tarea.FechaActualizacion

            };



            return Ok(respuesta);

        }




        [HttpPost]
        public async Task<IActionResult> CrearTarea(CrearTareaDto dto)
        {
            try
            {
                var tarea = new Tarea
                {
                    Titulo = dto.Titulo,
                    Descripcion = dto.Descripcion,
                    EstadoId = dto.EstadoId,
                    PrioridadId = dto.PrioridadId,
                    FechaCreacion = DateTime.Now
                };

                await _service.Crear(tarea);

                var tareaCreada = await _service.ObtenerPorId(tarea.Id);

                if (tareaCreada == null)
                {
                    return BadRequest(new
                    {
                        mensaje = "No se pudo recuperar la tarea creada"
                    });
                }

                var respuesta = new TareaRespuestaDto
                {
                    Id = tareaCreada.Id,
                    Titulo = tareaCreada.Titulo,
                    Descripcion = tareaCreada.Descripcion,
                    Estado = tareaCreada.Estado.Nombre,
                    Prioridad = tareaCreada.Prioridad.Nombre,
                    FechaCreacion = tareaCreada.FechaCreacion,
                    FechaActualizacion = tareaCreada.FechaActualizacion
                };

                return CreatedAtAction(
                    nameof(ObtenerTarea),
                    new { id = tareaCreada.Id },
                    respuesta
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensaje = "Error al crear tarea",
                    detalle = ex.InnerException?.Message ?? ex.Message
                });
            }
        }





        [HttpPut("{id}")]
        public async Task<IActionResult> EditarTarea(
            int id,
            ActualizarTareaDto dto)
        {

            try
            {

                var tarea = new Tarea
                {

                    Titulo = dto.Titulo,

                    Descripcion = dto.Descripcion,

                    EstadoId = dto.EstadoId,

                    PrioridadId = dto.PrioridadId,

                    FechaActualizacion = DateTime.Now

                };



                await _service.Actualizar(id, tarea);



                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensaje = "Error al actualizar tarea",
                    detalle = ex.InnerException?.Message ?? ex.Message
                });
            }

        }








        

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTarea(int id)
        {

            try
            {

                await _service.Eliminar(id);



                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensaje = ex.Message,
                    detalle = ex.InnerException?.Message,
                    stack = ex.StackTrace
                });
            }

        }







      

        [HttpGet("Filtrar")]
        public async Task<ActionResult<IEnumerable<TareaRespuestaDto>>> FiltrarTareas(
            int? estadoId,
            int? prioridadId)
        {


            var tareas = await _service.ObtenerTodas();



            if (estadoId.HasValue)
            {

                tareas = tareas
                    .Where(x => x.EstadoId == estadoId.Value)
                    .ToList();

            }




            if (prioridadId.HasValue)
            {

                tareas = tareas
                    .Where(x => x.PrioridadId == prioridadId.Value)
                    .ToList();

            }




            var respuesta = tareas.Select(x => new TareaRespuestaDto
            {

                Id = x.Id,

                Titulo = x.Titulo,

                Descripcion = x.Descripcion,

                Estado = x.Estado.Nombre,

                Prioridad = x.Prioridad.Nombre,

                FechaCreacion = x.FechaCreacion,

                FechaActualizacion = x.FechaActualizacion


            });



            return Ok(respuesta);

        }



    }

}