using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UTEQ.Models
{
    public class Cursos
    {


        [Key]

        public int Id { get; set; }


        [Required(ErrorMessage = "Campo Obligatorio")]
        public string nombrecurso { get; set; }



        [Required(ErrorMessage = "Campo Obligatorio")]
        public string fecha { get; set; }


        [Required(ErrorMessage = "Campo Obligatorio")]
        public string horario { get; set; }


        [Required(ErrorMessage = "Campo Obligatorio")]
        public string lugar { get; set; }



        [Required(ErrorMessage = "Campo Obligatorio")]
        public float totalhoras { get; set; }



        [Required(ErrorMessage = "Campo Obligatorio")]
        public float costo { get; set; }



        [Required(ErrorMessage = "Campo Obligatorio")]
        public float costopref { get; set; }



        [Required(ErrorMessage = "Campo Obligatorio")]
        public string urltemario { get; set; }



        [Required(ErrorMessage = "Campo Obligatorio")]
        public string requisitos { get; set; }



        [Required(ErrorMessage = "Campo Obligatorio")]
        public string criterioeval { get; set; }


        public string? ImagenUrl { get; set; }


        // Foreign Key
        public int ModalidadId { get; set; }

        [ForeignKey("ModalidadId")]
        public virtual Modalidad? Modalidad { get; set; }

    }
}
