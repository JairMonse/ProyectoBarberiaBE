using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BarberoDTO
{
    public class BarberoGetDTO
    {
        public int Id { get; set; }

        public string? Nombres { get; set; }

        public int EspecialidadId { get; set; }

        public string? Descripcion { get; set; }

        public int Experiencia { get; set; }

        public string? Telefono { get; set; }

        public int JornadaId { get; set; }

        public string? Disponibilidad { get; set; }

        public string? ImageName { get; set; }
    }
}
