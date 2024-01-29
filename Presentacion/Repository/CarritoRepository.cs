using Microsoft.EntityFrameworkCore;
using Models.Módulo_Carrito;
using Models.Módulo_Inventario;
using Presentacion.Infrastructure;

namespace Presentacion.Repository
{
    public class CarritoRepository: ICarritoRepository
    {
        private readonly AplicationDbContext _context;

        public CarritoRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Carrito>> GetListCarrito()
        {
            return await _context.CarritoCliente.ToListAsync();
        }

        public async Task<Carrito> GetCarrito(int id)
        {
            return await _context.CarritoCliente.FindAsync(id);
        }

        public async Task DeleteCarrito(Carrito carrito)
        {
            _context.CarritoCliente.Remove(carrito);
            await _context.SaveChangesAsync();
        }

        public async Task<Carrito> AddCarrito(Carrito carrito)
        {
            _context.Add(carrito);
            await _context.SaveChangesAsync();
            return carrito;
        }

        public async Task UpdateCarrito(Carrito carrito)
        {
            var carritoItem = await _context.CarritoCliente.FirstOrDefaultAsync(x => x.Id == carrito.Id);

            if (carritoItem != null)
            {
                carritoItem.name = carrito.name;
                carritoItem.cantidad = carrito.cantidad;
                carritoItem.precio = carrito.precio;
                carritoItem.total = carrito.total;

                await _context.SaveChangesAsync();

            }


        }

    }
}
