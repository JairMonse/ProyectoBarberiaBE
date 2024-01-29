using Models.Módulo_Citas;
using Models.Módulo_Cliente;

namespace Presentacion.Repository
{
    public interface ICitasRepository
    {
        Task<List<Citas>> GetListCitas();
        Task<Citas> GetCitas(int id);
        Task DeleteCita(Citas citas);
        Task<Citas> AddCita(Citas citas);
        Task UpdateCita(Citas citas);




    }
}
