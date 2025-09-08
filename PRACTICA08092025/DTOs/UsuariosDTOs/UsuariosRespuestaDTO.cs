namespace PRACTICA08092025.DTOs.UsuariosDTOs
{
    public class UsuariosRespuestaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Email { get; set; } = "";
        public string Rol { get; set; } = "";

        public string Token { get; set; } = "";
    }
}
