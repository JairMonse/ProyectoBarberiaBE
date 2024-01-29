using Microsoft.EntityFrameworkCore;
using Models.Módulo_Citas;
using Presentacion.Infrastructure;

namespace Presentacion.Repository
{
    public class CitasRepository : ICitasRepository
    {
        private readonly AplicationDbContext _context;

        public CitasRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Citas>> GetListCitas()
        {
            return await _context.CitasCliente.ToListAsync();
        }
        public async Task<Citas> GetCitas(int id)
        {
            return await _context.CitasCliente.FindAsync(id);
        }

        public async Task DeleteCita(Citas citas)
        {
            _context.CitasCliente.Remove(citas);
            await _context.SaveChangesAsync();
        }

        public async Task<Citas> AddCita(Citas citas)
        {
            _context.Add(citas);
            await _context.SaveChangesAsync();
            return citas;
        }

        public async Task UpdateCita(Citas citas)
        {
            var citaItem = await _context.CitasCliente.FirstOrDefaultAsync(x => x.Id == citas.Id);

            if (citaItem != null)
            {
                citaItem.fechaCita = citas.fechaCita;
                citaItem.hora = citas.hora;
                citaItem.nombreBarbero = citas.nombreBarbero;
                citaItem.nombreCliente = citas.nombreCliente;
                citaItem.telefono = citas.telefono;
                citaItem.correoE = citas.correoE;

                await _context.SaveChangesAsync();

            }


        }
    }
}
