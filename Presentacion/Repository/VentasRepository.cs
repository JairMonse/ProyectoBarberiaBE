using Microsoft.EntityFrameworkCore;
using Models.Módulo_Citas;
using Models.Módulo_Ventas;
using Presentacion.Infrastructure;

namespace Presentacion.Repository
{
    public class VentasRepository : IVentasRepository
    {
        private readonly AplicationDbContext _context;

        public VentasRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ventas>> GetListVentas()
        {
            return await _context.Ventas.ToListAsync();
        }
        public async Task<Ventas> GetVentas(int id)
        {
            return await _context.Ventas.FindAsync(id);
        }

        public async Task DeleteVenta(Ventas ventas)
        {
            _context.Ventas.Remove(ventas);
            await _context.SaveChangesAsync();
        }

        public async Task<Ventas> AddVenta(Ventas ventas)
        {
            _context.Add(ventas);
            await _context.SaveChangesAsync();
            return ventas;
        }

        public async Task UpdateVenta(Ventas ventas)
        {
            var ventaItem = await _context.Ventas.FirstOrDefaultAsync(x => x.Id == ventas.Id);

            if (ventaItem != null)
            {
                ventaItem.fechaRegistro = ventas.fechaRegistro;
                ventaItem.nombreCliente = ventas.nombreCliente;
                ventaItem.nombreProducto = ventas.nombreProducto;
                ventaItem.cantidad = ventas.cantidad;
                ventaItem.metodoPago = ventas.metodoPago;

                await _context.SaveChangesAsync();

            }


        }

    }
}
