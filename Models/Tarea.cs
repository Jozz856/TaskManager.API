namespace TaskManager.API.Modelos
{
    public class Tarea
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;


        public int EstadoId { get; set; }

        public CatEstado Estado { get; set; } = null!;


        public int PrioridadId { get; set; }

        public CatPrioridad Prioridad { get; set; } = null!;


        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }
    }
}