namespace TaskManager.API.Modelos
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public string NombreUsuario { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
