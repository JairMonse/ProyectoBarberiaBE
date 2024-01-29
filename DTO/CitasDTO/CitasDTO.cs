using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.CitasDTO
{
    public class CitasDTO
    {
        public int Id { get; set; }
        public string fechaCita { get; set; }
        public string hora { get; set; }
        public string nombreBarbero { get; set; }
        public string nombreCliente { get; set; }
        public int telefono { get; set; }
        public string correoE { get; set; }

        public string tipoServicio { get; set; }

    }
}
