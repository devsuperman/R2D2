using Microsoft.EntityFrameworkCore;
using Dominio.Models;

namespace R2D2.Data;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Tarea> Tareas { get; set; } = default!;
}
