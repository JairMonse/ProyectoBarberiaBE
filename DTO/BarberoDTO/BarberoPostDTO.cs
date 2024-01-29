using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BarberoDTO
{
    public class BarberoPostDTO
    {

        public string? Nombres { get; set; }

        public int EspecialidadId { get; set; }

        public int JornadaId { get; set; }

        public int Experiencia { get; set; }

        public string? Telefono { get; set; }

        public string? ImageName { get; set; }

    }
}
