using CursoEF6.Data;
using CursoEF6.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoEF6.Controllers
{
    public class EtiquetasController : Controller
    {
        private readonly ApplicationDbContext contexto;

        public EtiquetasController(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }
        public IActionResult Index()
        {
            List<Etiqueta> etiquetas = new List<Etiqueta>();
            etiquetas = contexto.Etiquetas.ToList();
            return View(etiquetas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                contexto.Etiquetas.Add(etiqueta);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            

            return View(etiqueta);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return View();
            }

            var etiqueta = contexto.Etiquetas.FirstOrDefault(et => et.EtiquetaId == id);
            if (etiqueta is null)
            {
                return View();
            }


            return View(etiqueta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                contexto.Etiquetas.Update(etiqueta);
                contexto.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(etiqueta);
            
        }


        [HttpGet]
        public IActionResult Borrar(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return View();
            }

            var etiqueta = contexto.Etiquetas.FirstOrDefault(et => et.EtiquetaId == id);
            if(etiqueta is null)
            {
                return NotFound();
            }

            contexto.Remove(etiqueta);
            contexto.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
