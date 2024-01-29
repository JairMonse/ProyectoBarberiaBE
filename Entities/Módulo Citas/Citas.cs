using System.ComponentModel.DataAnnotations;

namespace Models.Módulo_Citas
{
    public class Citas
    {
        [Key]
        public int Id { get; set; }
        public string fechaCita { get; set; }
        public string hora { get; set; }

        [Required]
        [StringLength(255)]
        public string nombreBarbero {get; set;}

        [Required]
        [StringLength(255)]
        public string nombreCliente { get;set; }

        [Required]
        [StringLength(10)]
        public int telefono {  get; set; }

        [Required]
        [StringLength(255)]
        public string correoE {  get; set; }

        [Required]
        [StringLength(255)]
        public string tipoServicio { get; set; }


        [Required]
        public DateTime fechaCreacion { get; set; }


    }
}
