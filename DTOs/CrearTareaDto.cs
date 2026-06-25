namespace TaskManager.API.DTOs
{
    public class CrearTareaDto
    {
        public string Titulo { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;


        public int EstadoId { get; set; }


        public int PrioridadId { get; set; }
    }
}