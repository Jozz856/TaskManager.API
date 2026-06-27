using TaskManager.API.Datos;
using TaskManager.API.Modelos;
using TaskManager.API.Repositories;

namespace TaskManager.API.Services
{
    public class TareaService : ITareaService
    {

        private readonly ITareaRepository _repository;

        private readonly ContextoBaseDatos _contexto;



        public TareaService(
            ITareaRepository repository,
            ContextoBaseDatos contexto)
        {
            _repository = repository;
            _contexto = contexto;
        }





        // =====================================
        // OBTENER TODAS
        // =====================================

        public async Task<List<Tarea>> ObtenerTodas()
        {

            return await _repository.ObtenerTodas();

        }






        // =====================================
        // OBTENER POR ID
        // =====================================

        public async Task<Tarea?> ObtenerPorId(int id)
        {

            return await _repository.ObtenerPorId(id);

        }






        // =====================================
        // CREAR
        // =====================================

        public async Task Crear(Tarea tarea)
        {


            if (string.IsNullOrEmpty(tarea.Titulo))
            {
                throw new Exception(
                    "El título es obligatorio"
                );
            }



            await _repository.Crear(tarea);



            // ==============================
            // CREAR LOG
            // ==============================

            var log = new LogTarea
            {
                TareaId = tarea.Id,

                Usuario = "Sistema",

                Accion = "CREAR",

                Fecha = DateTime.Now,

                Detalle =
                "Se creó la tarea: " + tarea.Titulo
            };



            _contexto.LogTareas.Add(log);


            await _contexto.SaveChangesAsync();


        }






        // =====================================
        // ACTUALIZAR
        // =====================================

        public async Task Actualizar(
            int id,
            Tarea tarea)
        {


            var tareaExistente =
                await _repository.ObtenerPorId(id);



            if (tareaExistente == null)
            {
                throw new Exception(
                    "La tarea no existe"
                );
            }



            tareaExistente.Titulo =
                tarea.Titulo;


            tareaExistente.Descripcion =
                tarea.Descripcion;


            tareaExistente.EstadoId =
                tarea.EstadoId;


            tareaExistente.PrioridadId =
                tarea.PrioridadId;


            tareaExistente.FechaActualizacion =
                DateTime.Now;



            await _repository.Actualizar(
                tareaExistente
            );





            // ==============================
            // LOG EDITAR
            // ==============================


            var log = new LogTarea
            {
                TareaId = tareaExistente.Id,

                Usuario = "Sistema",

                Accion = "EDITAR",

                Fecha = DateTime.Now,

                Detalle =
                "Se actualizó la tarea: "
                + tareaExistente.Titulo
            };



            _contexto.LogTareas.Add(log);



            await _contexto.SaveChangesAsync();


        }









        public async Task Eliminar(int id)
        {

            var tarea =
                await _repository.ObtenerPorId(id);


            if (tarea == null)
            {
                throw new Exception(
                    "La tarea no existe"
                );
            }


            var titulo = tarea.Titulo;




            var log = new LogTarea
            {
                TareaId = id,

                Usuario = "Sistema",

                Accion = "ELIMINAR",

                Fecha = DateTime.Now,

                Detalle =
                "Se eliminó la tarea: "
                + titulo
            };


            _contexto.LogTareas.Add(log);


            await _contexto.SaveChangesAsync();




            await _repository.Eliminar(tarea);


            await _contexto.SaveChangesAsync();


        }


    }
}