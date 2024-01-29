using Models.Módulo_Citas;
using Models.Módulo_Ventas;

namespace Presentacion.Repository
{
    public interface IVentasRepository
    {
        Task<List<Ventas>> GetListVentas();
        Task<Ventas> GetVentas(int id);
        Task DeleteVenta(Ventas ventas);
        Task<Ventas> AddVenta(Ventas ventas);
        Task UpdateVenta(Ventas ventas);


    }
}
