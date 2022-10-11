using CursoEF6.Data;
using CursoEF6.Models;
using CursoEF6.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CursoEF6.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly ApplicationDbContext contexto;

        public ArticulosController(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

        public IActionResult Index()
        {
            //List<Articulo> listaArticulos = contexto.Articulos.Take(15).ToList();
            //Carga explicita
            //foreach(var articulo in listaArticulos)
            //{
            //    contexto.Entry(articulo).Reference(art => art.Categoria).Load();
            //}

            //Carga diligente
            List<Articulo> listaArticulos =
                contexto.Articulos.Include(cat => cat.Categoria).Take(15).ToList();
            return View(listaArticulos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ArticuloCategoriaVM articuloCategorias = new ArticuloCategoriaVM();
            articuloCategorias.ListaCategorias = contexto
                .Categorias.Select(cat => new SelectListItem
                {
                    Text = cat.Nombre,
                    Value = cat.Categoria_Id.ToString()
                });

            return View(articuloCategorias);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                contexto.Articulos.Add(articulo);
                contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ArticuloCategoriaVM articuloCategorias = new ArticuloCategoriaVM();
            articuloCategorias.ListaCategorias = contexto
                .Categorias.Select(cat => new SelectListItem
                {
                    Text = cat.Nombre,
                    Value = cat.Categoria_Id.ToString()
                });

            return View(articuloCategorias);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id is null)
            {
                return View();
            }

            ArticuloCategoriaVM articuloCategorias = new ArticuloCategoriaVM();
            articuloCategorias.ListaCategorias = contexto
                .Categorias.Select(cat => new SelectListItem
                {
                    Text = cat.Nombre,
                    Value = cat.Categoria_Id.ToString()
                });

            articuloCategorias.Articulo =
                contexto.Articulos.FirstOrDefault(art => art.Articulo_Id == id);

            if (articuloCategorias is null)
            {
                return NotFound();
            }

            return View(articuloCategorias);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ArticuloCategoriaVM articuloCategoriaVM)
        {
            if (articuloCategoriaVM.Articulo.Articulo_Id == 0)
            {

                return View(articuloCategoriaVM.Articulo);
            }

            else
            {
                contexto.Articulos.Update(articuloCategoriaVM.Articulo);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Borrar(int id)
        {
            if (id == 0)
            {
                return View("Index");
            }

            var articulo = contexto.Articulos.FirstOrDefault(art => art.Articulo_Id == id);
            if (articulo is null)
            {
                return View("Index");
            }

            contexto.Articulos.Remove(articulo);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AdministrarEtiquetas(int id)
        {
            var articuloEtiquetas = new ArticuloEtiquetaVM()
            {
                ListaArticuloEtiquetas =
                 contexto.ArticuloEtiquetas.Include(ae => ae.Etiqueta)
                                           .Include(ae => ae.Articulo)
                                           .Where(ae => ae.Articulo_Id == id),

                ArticuloEtiqueta = new ArticuloEtiqueta(){Articulo_Id = id},

                Articulo = contexto.Articulos.FirstOrDefault(art => art.Articulo_Id == id)

            };

            //Trae todos los ids de las etiquetas de la clase articuloEtiquetas
            List<int> listaTemporalEtiquetasArticulo =
                articuloEtiquetas
                .ListaArticuloEtiquetas
                .Select(ae => ae.EtiquetaId).ToList();

            //Obtiene los ids de las etiquetas que no están en la lista temporal
            var listaTemporal =
                contexto.Etiquetas
                .Where(et => !listaTemporalEtiquetasArticulo
                      .Contains(et.EtiquetaId)).ToList();

            //Lista de etiquetas para el dropdown
            articuloEtiquetas.ListaEtiquetas =
                listaTemporal.Select(et => new SelectListItem
                {
                    Text = et.Titulo,
                    Value = et.EtiquetaId.ToString()
                });

            return View(articuloEtiquetas);

        }

        [HttpPost]
        public IActionResult AdministrarEtiquetas(ArticuloEtiquetaVM articuloEtiquetas)
        {
            if (articuloEtiquetas.ArticuloEtiqueta.Articulo_Id != 0 
                && articuloEtiquetas.ArticuloEtiqueta.EtiquetaId != 0)
            {
                contexto.ArticuloEtiquetas.Add(articuloEtiquetas.ArticuloEtiqueta);
                contexto.SaveChanges();  
            }

            return RedirectToAction("AdministrarEtiquetas", 
                new { @id = articuloEtiquetas.ArticuloEtiqueta.Articulo_Id });
        }

        //Este nombre de id deber ser el mismo del asp-route-idEtiqueta de la vista
        public IActionResult EliminarEtiqueta(int idEtiqueta, 
            ArticuloEtiquetaVM articuloEtiquetas)
        {
            int idArticulo = articuloEtiquetas.Articulo.Articulo_Id;

            ArticuloEtiqueta articuloEtiqueta = contexto.ArticuloEtiquetas.FirstOrDefault(
                ae => ae.EtiquetaId == idEtiqueta && ae.Articulo_Id == idArticulo
                );

            contexto.ArticuloEtiquetas.Remove(articuloEtiqueta);
            contexto.SaveChanges();

            return RedirectToAction("AdministrarEtiquetas",
                new { @id = idArticulo });

        }

    }
}
