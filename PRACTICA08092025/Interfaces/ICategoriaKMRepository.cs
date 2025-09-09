using PRACTICA08092025.Entidades;

namespace PRACTICA08092025.Interfaces
{
    public interface ICategoriaKMRepository
    {
        Task<List<CategoriaKM>> GetAllAsync();
        Task<CategoriaKM?> GetByIdAsync(int id);
        Task<CategoriaKM> AddAsync(CategoriaKM entity);
        Task<bool> UpdateAsync(CategoriaKM entity);
        Task<bool> DeleteAsync(int id);
    }
}
