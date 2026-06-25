using TaskManager.API.Modelos;


namespace TaskManager.API.Services
{
    public interface ITareaService
    {


        Task<List<Tarea>> ObtenerTodas();


        Task<Tarea?> ObtenerPorId(int id);


        Task Crear(Tarea tarea);


        Task Actualizar(int id, Tarea tarea);


        Task Eliminar(int id);

    }
}