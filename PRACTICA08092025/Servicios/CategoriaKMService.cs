using PRACTICA08092025.DTOs.CategoriaDTOs;
using PRACTICA08092025.Entidades;
using PRACTICA08092025.Interfaces;

namespace PRACTICA08092025.Servicios
{
    public class CategoriaKMService : ICategoriaKMService
    {
        private readonly ICategoriaKMRepository _repo;

        public CategoriaKMService(ICategoriaKMRepository repo) => _repo = repo;

        public async Task<List<CategoriaResponseKMDTO>> GetAllAsync() =>
            (await _repo.GetAllAsync()).Select(x => new CategoriaResponseKMDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion
            }).ToList();

        public async Task<CategoriaResponseKMDTO?> GetByIdAsync(int id)
        {
            var x = await _repo.GetByIdAsync(id);
            return x == null ? null : new CategoriaResponseKMDTO
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion
            };
        }

        public async Task<CategoriaResponseKMDTO> CreateAsync(CategoriaCreateKMDTO dto)
        {
            var entity = new CategoriaKM { Nombre = dto.Nombre.Trim(), Descripcion = dto.Descripcion.Trim() };
            var saved = await _repo.AddAsync(entity);
            return new CategoriaResponseKMDTO { Id = saved.Id, Nombre = saved.Nombre, Descripcion = saved.Descripcion };
        }

        public async Task<bool> UpdateAsync(int id, CategoriaUpdateKMDTO dto)
        {
            var current = await _repo.GetByIdAsync(id);
            if (current == null) return false;
            current.Nombre = dto.Nombre.Trim();
            current.Descripcion = dto.Descripcion.Trim();
            return await _repo.UpdateAsync(current);
        }

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
