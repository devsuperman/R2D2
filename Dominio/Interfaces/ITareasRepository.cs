using Dominio.Models;

namespace Dominio.Interfaces
{
    public interface ITareasRepository
    {
        Task<Tarea> AddAsync(Tarea model);
        Task<Tarea> DeleteAsync(int id);
        Task<List<Tarea>> GetAllAsync();
        Task<Tarea> GetAsync(int id);
        Task<Tarea> UpdateAsync(Tarea model);
    }
}