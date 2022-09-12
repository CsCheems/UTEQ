using Microsoft.AspNetCore.Mvc;
using UTEQ.Datos;
using UTEQ.Models;

namespace UTEQ.Controllers
{

    public class FormularioController : Controller
    {

        private readonly ApplicationDbContext _db;



        public FormularioController (ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<FormularioUsuario> lista = _db.FormularioUsuario;

            return View(lista);
        }
        // Get
        public IActionResult Crear()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(FormularioUsuario formulario)
        {
            if (ModelState.IsValid)
            {
                _db.FormularioUsuario.Add(formulario);
                _db.SaveChanges();


                return RedirectToAction(nameof(Crear));
            }
            return View(formulario);
        }
    }

}

