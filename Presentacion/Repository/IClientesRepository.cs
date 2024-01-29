using Models.Módulo_Citas;
using Models.Módulo_Cliente;

namespace Presentacion.Repository
{
    public interface IClientesRepository
    {
        Task DeleteCliente(Cliente cliente);
        Task<Cliente> GetClientes(int id);
    }
}
