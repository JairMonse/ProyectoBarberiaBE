using Models.Módulo_Barbero;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Models.Módulo_Cliente
{
    [Table("Clientes")]
    [Index("Cedula")]
    public class Cliente
    {

        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(10)]
        public string? Cedula { get; set; }


        [Required]
        [StringLength(255)]
        public string? Nombre { get; set; }


        [Required]
        [StringLength(255)]
        public string? Apellido { get; set; }


        [Required]
        [StringLength(100)]
        public string? Correo { get; set; }


        [Required]
        [StringLength(50)]
        public string? Usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string? Contrasena { get; set; }


        [Required]
        public bool Estado { get; set; }


        [Required]
        public DateTime FechaReg { get; set; }


    }
}
