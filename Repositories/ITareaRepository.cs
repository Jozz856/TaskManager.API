using TaskManager.API.Modelos;

namespace TaskManager.API.Repositories
{
    public interface ITareaRepository
    {

        Task<List<Tarea>> ObtenerTodas();


        Task<Tarea?> ObtenerPorId(int id);


        Task Crear(Tarea tarea);


        Task Actualizar(Tarea tarea);


        Task Eliminar(Tarea tarea);

    }
}