using Models.Módulo_Inventario;

namespace Presentacion.Repository
{
    public interface IInventarioRepository
    {
        Task<List<Inventario>> GetListInventario();
        Task<Inventario> GetInventario(int id);
        Task DeleteInventario(Inventario inventario);
        Task<Inventario> AddInventario(Inventario inventario);
        Task UpdateInventario(Inventario inventario);
    }
}
