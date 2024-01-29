using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BarberoDTO
{
    public class BarberoPageDTO
    {
        public string? Nombres { get; set; }

        public string? Descripcion { get; set; }

        public int Experiencia { get; set; }

        public string? Telefono { get; set; }

        public string? Disponibilidad { get; set;}

        public string? ImageName { get; set; }

    }
}
