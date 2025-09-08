using PRACTICA08092025.DTOs.UsuariosDTOs;
using PRACTICA08092025.Entidades;

namespace PRACTICA08092025.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuarios?> GetByEmailAsync(string email);

        Task<Usuarios> AddAsync(Usuarios usuario);

        Task <List<UsuariosListadoDTO>> GetAllUsuariosAsync();
    }
}
