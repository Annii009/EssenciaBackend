using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Essencia.Backend.Repositories
{
    public class ProductosFloristeriaRepository : IProductosFloristeriaRepository
    {
        private readonly EssenciaDbContext _context;

        public ProductosFloristeriaRepository(EssenciaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductosFloristeria>> GetAllAsync()
        {
            return await _context.ProductosFloristeria.ToListAsync();
        }

        public async Task<ProductosFloristeria?> GetByIdAsync(int id)
        {
            return await _context.ProductosFloristeria.FindAsync(id);
        }

        public async Task AddAsync(ProductosFloristeria producto)
        {
            await _context.ProductosFloristeria.AddAsync(producto);
            await _context.SaveChangesAsync();
        }
    }
}