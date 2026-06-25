using Microsoft.EntityFrameworkCore;
using TaskManager.API.Datos;
using TaskManager.API.Modelos;

namespace TaskManager.API.Repositories
{
    public class TareaRepository : ITareaRepository
    {

        private readonly ContextoBaseDatos _contexto;


        public TareaRepository(ContextoBaseDatos contexto)
        {
            _contexto = contexto;
        }



        public async Task<List<Tarea>> ObtenerTodas()
        {

            return await _contexto.Tareas
                .Include(x => x.Estado)
                .Include(x => x.Prioridad)
                .ToListAsync();

        }




        public async Task<Tarea?> ObtenerPorId(int id)
        {

            return await _contexto.Tareas
                .Include(x => x.Estado)
                .Include(x => x.Prioridad)
                .FirstOrDefaultAsync(x => x.Id == id);

        }



        

        public async Task Crear(Tarea tarea)
        {

            _contexto.Tareas.Add(tarea);

            await _contexto.SaveChangesAsync();

        }




        public async Task Actualizar(Tarea tarea)
        {

            _contexto.Tareas.Update(tarea);

            await _contexto.SaveChangesAsync();

        }



    

        public async Task Eliminar(Tarea tarea)
        {

            _contexto.Tareas.Remove(tarea);

            await _contexto.SaveChangesAsync();

        }


    }
}
