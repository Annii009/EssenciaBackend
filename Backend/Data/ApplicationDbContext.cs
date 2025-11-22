using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Essencia.Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductosFloristeria> ProductosFloristeria { get; set; }
        public DbSet<ProductosCafeteria> ProductosCafeteria { get; set; }
        public DbSet<IngredientesCafeteria> IngredientesCafeteria { get; set; }
    }
}