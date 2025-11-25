using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Essencia.Backend.Data
{
    public class EssenciaDbContext : DbContext
    {
        public EssenciaDbContext(DbContextOptions<EssenciaDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductosFloristeria> ProductosFloristeria { get; set; }
        // public DbSet<ProductosCafeteria> ProductosCafeteria { get; set; }
        // public DbSet<IngredientesCafeteria> IngredientesCafeteria { get; set; }
    }
}