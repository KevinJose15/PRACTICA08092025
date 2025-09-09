using Microsoft.EntityFrameworkCore;
using PRACTICA08092025.Entidades;
using PRACTICA08092025.Interfaces;

namespace AuthApi.Repositorios
{
    public class CategoriaKMRepository : ICategoriaKMRepository
    {
        private readonly AppDbContext _context;

        public CategoriaKMRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriaKM>> GetAllAsync()
            => await _context.Categorias.AsNoTracking().ToListAsync();

        public async Task<CategoriaKM?> GetByIdAsync(int id)
            => await _context.Categorias.FindAsync(id);

        public async Task<CategoriaKM> AddAsync(CategoriaKM entity)
        {
            _context.Categorias.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(CategoriaKM entity)
        {
            _context.Categorias.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Categorias.FindAsync(id);
            if (existing == null) return false;
            _context.Categorias.Remove(existing);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}