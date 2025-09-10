using PRACTICA08092025.Entidades;

namespace PRACTICA08092025.Interfaces
{
    public interface ICategoriaKMRepository
    {
        Task<List<Categoriaskm>> GetAllAsync();
        Task<Categoriaskm?> GetByIdAsync(int id);
        Task<Categoriaskm> AddAsync(Categoriaskm entity);
        Task<bool> UpdateAsync(Categoriaskm entity);
        Task<bool> DeleteAsync(int id);
    }
}
