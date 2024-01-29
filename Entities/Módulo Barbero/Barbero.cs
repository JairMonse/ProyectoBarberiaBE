using Models.Módulo_Barbero;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Barberos")]
    public class Barbero
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Nombres { get; set; }

        [Required]
        public int EspecialidadId { get; set; }

        [Required]
        public int JornadaId { get; set; }

        [Required]
        public int Experiencia { get; set; }

        [Required]
        [StringLength(10)]
        public string? Telefono { get; set; }

        [Required]
        [StringLength(255)]
        public string? ImageName { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public DateTime FechaReg { get; set; }

        public virtual Especialidad Especialidad { get; set; }

        public virtual Jornada Jornada { get; set; }

    }
}
