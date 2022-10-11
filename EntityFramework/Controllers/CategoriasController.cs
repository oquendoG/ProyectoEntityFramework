using CursoEF6.Data;
using CursoEF6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoEF6.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext contexto;

        public CategoriasController(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

        public IActionResult Index()
        {

            //var listaCategorias = contexto.categorias
            //    .FromSqlRaw("SELECT * FROM categorias WHERE nombre LIKE 'categoria%'")
            //    .ToList();

            //int id = 20;
            //var listaCategorias = contexto.categorias
            //    .FromSqlRaw($"SELECT * FROM categorias WHERE Categoria_Id = {id}")
            //    .ToList();

            List<Categoria> listaCategorias = contexto.Categorias.Take(15).ToList();
            return View(listaCategorias);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                contexto.Categorias.Add(categoria);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult VistaCrearMultiplesCategorias()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearMultiplesCategorias()
        {
            //El request retorna un string con todos los valores separados por comas
            string categoriasForm = Request.Form["Nombre"];
            var listaCategorias = from val in categoriasForm.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries) select val;

            List<Categoria> categorias = new List<Categoria>();

            foreach(var cat in listaCategorias)
            {
                categorias.Add(new Categoria { Nombre = cat });
            }

            contexto.Categorias.AddRange(categorias);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if(id is null)
            {
                return View();
            }

            var categoria = contexto.Categorias.FirstOrDefault(cat => cat.Categoria_Id == id);
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                contexto.Categorias.Update(categoria);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var categoria = contexto.Categorias.FirstOrDefault(cat => cat.Categoria_Id == id);
            contexto.Categorias.Remove(categoria);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
