using Microsoft.EntityFrameworkCore;
using Dominio.Interfaces;
using Dominio.Models;
using R2D2.Data;

namespace R2D2.Services
{
    public class TareasRepository : ITareasRepository
    {
        private readonly Contexto _db;

        public TareasRepository(Contexto db)
        {
            _db = db;
        }

        public async Task<Tarea> AddAsync(Tarea model)
        {
            _db.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<Tarea> DeleteAsync(int id)
        {
            var model = await _db.Tareas.FindAsync(id);

            _db.Tareas.Remove(model);

            await _db.SaveChangesAsync();

            return model;
        }

        public async Task<List<Tarea>> GetAllAsync()
        {
            return await _db.Tareas.ToListAsync();
        }

        public async Task<Tarea> GetAsync(int id)
        {
            return await _db.Tareas.FindAsync(id);
        }

        public async Task<Tarea> UpdateAsync(Tarea model)
        {
            _db.Update(model);
            await _db.SaveChangesAsync();
            return model;
        }
    }
}
