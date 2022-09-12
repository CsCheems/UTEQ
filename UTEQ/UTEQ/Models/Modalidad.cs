using System.ComponentModel.DataAnnotations;
namespace UTEQ.Models
{
    public class Modalidad
    {
        [Key]

        public int Id { get; set; }
        public string nombreModalidad { get; set; }

    }
}
