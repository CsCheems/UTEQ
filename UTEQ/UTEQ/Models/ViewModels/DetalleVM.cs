namespace UTEQ.Models.ViewModels
{
    public class DetalleVM
    {
        public DetalleVM ()
        {
            Cursos = new Cursos();
        }


        public Cursos Cursos { get; set; } 
         public bool ExisteEnCarro  { get; set; }
    }
}
