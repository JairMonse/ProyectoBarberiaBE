using Models.Módulo_Carrito;
using Models.Módulo_Inventario;

namespace Presentacion.Repository
{
    public interface ICarritoRepository
    {
        Task<List<Carrito>> GetListCarrito();
        Task<Carrito> GetCarrito(int id);
        Task DeleteCarrito(Carrito carrito);
        Task<Carrito> AddCarrito(Carrito carrito);
        Task UpdateCarrito(Carrito carrito);


    }
}
