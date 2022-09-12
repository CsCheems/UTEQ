using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UTEQ.Datos;
using System.Linq;
using System.IO;
using UTEQ.Models;
using static System.Net.Mime.MediaTypeNames;
using UTEQ.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace UTEQ.Controllers
{
    [Authorize(Roles =ED.AdminRole)]
    public class CursosController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public CursosController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Cursos> lista = _db.Cursos.Include(c => c.Modalidad);

            return View(lista);
        }

        // Get
        public IActionResult Upsert(int? Id)
        {

            //IEnumerable<SelectListItem> modalidadDropDown = _db.Modalidad.Select (c=> new SelectListItem
            //{
            //    Text = c.nombreModalidad,

            //    Value = c.Id.ToString()
            //});
            //ViewBag.modalidadDropDown = modalidadDropDown;
            //Cursos cursos = new Cursos();




            CursosVm cursosVm = new CursosVm()
            {
                Cursos= new Cursos (),
                ModalidadLista=_db.Modalidad.Select(c => new SelectListItem

                {
                    Text = c.nombreModalidad,
                    Value = c.Id.ToString()
                })


             };

            if (Id == null)
            { 
                return View (cursosVm); 
            }
            else
            {
                cursosVm.Cursos = _db.Cursos.Find (Id);
                if (cursosVm.Cursos == null)
                {
                    return NotFound();
                }
                return View (cursosVm); 
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CursosVm cursosVm)
        {
            if(ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                if(cursosVm.Cursos.Id==0)
                {
                    //Crear

                    string upload = webRootPath + ED.ImagenRuta;
                    string fileName=Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);


                    using (var fileStream = new FileStream(Path.Combine(upload,fileName+extension),FileMode.Create ))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    cursosVm.Cursos.ImagenUrl = fileName + extension;
                    _db.Cursos.Add(cursosVm.Cursos);
                }
                else
                {
                    //Actualizar
                    var objCurso = _db.Cursos.AsNoTracking().FirstOrDefault(p => p.Id == cursosVm.Cursos.Id);

                    if(files.Count>0)//se carga nueva imagen
                    {
                        string upload = webRootPath + ED.ImagenRuta;
                        string fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);

                        //borrar imagen anterior
                        var anteriorFile = Path.Combine(upload, objCurso.ImagenUrl);
                        if (System.IO.File.Exists(anteriorFile))
                        {
                            System.IO.File.Delete(anteriorFile);
                        }
                        // fin Borrar imagen anterior

                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }

                         cursosVm.Cursos.ImagenUrl = fileName + extension;
                    }// Caso contrario si no se carga una nueva imagen

                    else
                    {
                       cursosVm.Cursos.ImagenUrl = objCurso.ImagenUrl;
                    }
                    _db.Cursos.Update(cursosVm.Cursos);

                }
                // Se llenan nuevamente las listas si algo falla
                cursosVm.ModalidadLista = _db.Modalidad.Select(c => new SelectListItem

                {
                    Text = c.nombreModalidad,
                    Value = c.Id.ToString()
                });

                _db.SaveChanges();
                return RedirectToAction("Index");
            }//If ModelIsValid
            return View(cursosVm);
        }
        //Get

        public IActionResult Eliminar(int? Id)
        {

            if (Id == null || Id == 0)
            {
                return NotFound();
            }


            Cursos cursos=_db.Cursos.Include(c => c.Modalidad)
                             .FirstOrDefault(p => p.Id == Id);

            if (cursos == null)
            {
                return NotFound();
            }
            return View(cursos);
        }
        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Cursos cursos)
        {
            if (cursos == null)
            {
                return NotFound();
            }

            string upload = _webHostEnvironment.WebRootPath + ED.ImagenRuta;
            

            //borrar imagen anterior
            var anteriorFile = Path.Combine(upload,cursos.ImagenUrl);
            if (System.IO.File.Exists(anteriorFile))
            {
                System.IO.File.Delete(anteriorFile);
            }
            // fin Borrar imagen anterior

            _db.Cursos.Remove(cursos);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }




    }
}
