using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Módulo_Inventario
{
    public class Inventario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string nombreProducto { get; set; }

        public int cantidadProducto { get; set; }
        public float precio { get; set; }

        [Required]
        [StringLength(255)]
        public string descripcion { get; set; }

        [Required]
        [StringLength(255)]
        public string categoria { get; set; }

        [Required]
        public DateTime fechaCreacion { get; set; }
    }
}
