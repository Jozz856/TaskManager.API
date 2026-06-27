namespace TaskManager.API.Modelos
{
    public class LogTarea
    {

        public int LogId { get; set; }


        public int TareaId { get; set; }


        public string Usuario { get; set; } = string.Empty;


        public string Accion { get; set; } = string.Empty;


        public DateTime Fecha { get; set; }


        public string Detalle { get; set; } = string.Empty;



        // Navegación

        public Tarea Tarea { get; set; } = null!;


    }
}