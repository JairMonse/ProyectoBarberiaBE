using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.InventarioDTO
{
    public class InventarioDTO
    {
        public int Id { get; set; }
        public string nombreProducto { get; set; }
        public int cantidadProducto { get; set; }
        public float precio { get; set; }
        public string descripcion { get; set; }
        public string categoria { get; set; }

    }
}
