using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UTEQ.Datos;
using UTEQ.Models;
using UTEQ.Models.ViewModels;

namespace UTEQ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db; 


        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db) 
        {
            _logger = logger;
            _db= db; 

        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
               Cursoss=_db.Cursos.Include(c=>c.Modalidad),
               Modalidads=_db.Modalidad
            };

            //if (User.IsInRole(ED.AdminRole))

        //    {
        //        return View("Index");//Colocar nueva pantalla
        //}

                return View(homeVM);
        }

        public IActionResult Detalle (int Id)
        {
            DetalleVM detalleVM = new DetalleVM()
            {
                Cursos = _db.Cursos.Include(c => c.Modalidad)
                        .Where(p => p.Id == Id).FirstOrDefault(),

                ExisteEnCarro = false
            };
            return View(detalleVM);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}