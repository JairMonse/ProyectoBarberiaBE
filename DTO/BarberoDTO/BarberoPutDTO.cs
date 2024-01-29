using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BarberoDTO
{
    public class BarberoPutDTO
    {
        public int Id { get; set; }

        public string? Nombres { get; set; }

        public int EspecialidadId { get; set; }

        public int JornadaId { get; set; }

        public int Experiencia { get; set; }

        public string? Telefono { get; set; }

        public string? ImageName { get; set; }
    }
}
