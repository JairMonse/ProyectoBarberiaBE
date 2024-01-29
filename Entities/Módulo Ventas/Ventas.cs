using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Módulo_Ventas
{
    public class Ventas
    {
        [Key]
        public int Id { get; set; }
        public string fechaRegistro { get; set; }

        [Required]
        [StringLength(255)]
        public string nombreCliente { get; set; }

        [Required]
        [StringLength(255)]
        public string nombreProducto { get; set; }

        public int cantidad { get; set; }

        [Required]
        [StringLength(255)]
        public string metodoPago { get; set; }


        [Required]
        public DateTime fechaCreacion { get; set; }


    }
}
