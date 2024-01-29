using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Módulo_Barbero
{

    [Table("Jornadas")]
    public class Jornada
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? disponibilidad { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public DateTime FechaReg { get; set; }

        public virtual ICollection<Barbero> Barberos { get; set; } = new List<Barbero>();

    }
}
