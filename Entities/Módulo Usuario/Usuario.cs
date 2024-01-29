using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Usuarios")]
    public class Usuario
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Nombres { get; set; }


        [Required]
        [StringLength(255)]
        public string? Username { get; set; }


        [Required]
        [StringLength(255)]
        public string? Password { get; set; }


        [Required]
        public bool Estado { get; set; }


        [Required]
        public DateTime FechaReg { get; set; }


    }
}