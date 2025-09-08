using Microsoft.EntityFrameworkCore;
using PRACTICA08092025.DTOs.UsuariosDTOs;
using PRACTICA08092025.Entidades;
using PRACTICA08092025.Interfaces;

namespace AuthApi.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuarios?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.Include(u => u.Rol)
                                          .FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<Usuarios> AddAsync(Usuarios usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<List<UsuariosListadoDTO>> GetAllUsuariosAsync()
        {
            var usuarios = await _context.Usuarios
                                         .Include(u => u.Rol)
                                         .ToListAsync();

            return usuarios.Select(u => new UsuariosListadoDTO
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Email = u.Email,
                Rol = u.Rol?.Nombre ?? "Sin Rol"
            }).ToList();
        }
    }
}