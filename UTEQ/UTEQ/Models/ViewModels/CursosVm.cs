using Microsoft.AspNetCore.Mvc.Rendering;

namespace UTEQ.Models.ViewModels
{
    public class CursosVm
    {

        public Cursos Cursos { get; set; }

        public IEnumerable<SelectListItem>? ModalidadLista { get; set; }
    }
}
