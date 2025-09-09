using System.Collections.Generic;
using System.Threading.Tasks;
using PRACTICA08092025.DTOs.CategoriaDTOs;

namespace PRACTICA08092025.Interfaces
{
    public interface ICategoriaKMService // Debe ser una interfaz
    {
        Task<List<CategoriaResponseKMDTO>> GetAllAsync();
        Task<CategoriaResponseKMDTO?> GetByIdAsync(int id);
        Task<CategoriaResponseKMDTO> CreateAsync(CategoriaCreateKMDTO dto);
        Task<bool> UpdateAsync(int id, CategoriaUpdateKMDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}