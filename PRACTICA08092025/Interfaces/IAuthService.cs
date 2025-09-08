using PRACTICA08092025.DTOs.UsuariosDTOs;
namespace AuthApi.Interfaces

{
    public interface IAuthService
    {
        Task<UsuariosRespuestaDTO> RegistrarAsync(UsuariosRegistroDTO usuarioRegistroDTO);
        Task<UsuariosRespuestaDTO> LoginAsync(UsuariosLoginDTO usuarioLoginto);
    }
}