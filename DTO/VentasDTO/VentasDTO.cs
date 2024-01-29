using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.VentasDTO
{
    public class VentasDTO
    {
        public int Id { get; set; }
        public string fechaRegistro { get; set; }
        public string nombreCliente { get; set; }
        public string nombreProducto { get; set; }
        public int cantidad { get; set; }
        public string metodoPago { get; set; }

    }
}
