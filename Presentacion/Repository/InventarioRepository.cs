using Microsoft.EntityFrameworkCore;
using Models.Módulo_Inventario;
using Presentacion.Infrastructure;

namespace Presentacion.Repository
{
    public class InventarioRepository : IInventarioRepository
    {
        private readonly AplicationDbContext _context;

        public InventarioRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Inventario>> GetListInventario()
        {
            return await _context.Inventarios.ToListAsync();
        }
        public async Task<Inventario> GetInventario(int id)
        {
            return await _context.Inventarios.FindAsync(id);
        }

        public async Task DeleteInventario(Inventario inventario)
        {
            _context.Inventarios.Remove(inventario);
            await _context.SaveChangesAsync();
        }

        public async Task<Inventario> AddInventario(Inventario inventario)
        {
            _context.Add(inventario);
            await _context.SaveChangesAsync();
            return inventario;
        }

        public async Task UpdateInventario(Inventario inventario)
        {
            var inventarioItem = await _context.Inventarios.FirstOrDefaultAsync(x => x.Id == inventario.Id);

            if (inventarioItem != null)
            {
                inventarioItem.nombreProducto = inventario.nombreProducto;
                inventarioItem.cantidadProducto = inventario.cantidadProducto;
                inventarioItem.precio = inventario.precio;
                inventarioItem.descripcion = inventario.descripcion;
                inventarioItem.categoria = inventario.categoria;

                await _context.SaveChangesAsync();

            }


        }
    }
}
