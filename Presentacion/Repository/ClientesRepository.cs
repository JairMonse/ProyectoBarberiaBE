using Microsoft.EntityFrameworkCore;
using Models.Módulo_Citas;
using Models.Módulo_Cliente;
using Presentacion.Infrastructure;

namespace Presentacion.Repository
{
    public class ClientesRepository: IClientesRepository
    {
        private readonly AplicationDbContext _context;

        public ClientesRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> GetClientes(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }
    }
}
