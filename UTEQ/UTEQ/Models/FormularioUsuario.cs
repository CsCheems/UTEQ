using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UTEQ.Models
{
    public class FormularioUsuario
    {
        [Key]
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string NombreU { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string CorreoU { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public int whats { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public int otroTelefono { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string egresado { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string egresadoMod { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string carrera { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string estudiante { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string docente { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string publico { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string sugerencia { get; set; }



        //// Foreign Key
        //public int nombrecursoId { get; set; }

        //[ForeignKey("nombrecursoId")]
        //public virtual Cursos? Cursos { get; set; }



    }
}
