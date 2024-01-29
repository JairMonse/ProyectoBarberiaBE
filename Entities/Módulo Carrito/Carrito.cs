using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Módulo_Carrito
{
    public class Carrito
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }
        public int cantidad { get; set; }
        public float precio { get; set; }
        public float total { get; set; }

        [Required]
        public DateTime fechaCreacion { get; set; }
    }
}
