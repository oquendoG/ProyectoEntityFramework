using CursoEF6.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CursoEF6.ViewModels
{
    public class ArticuloCategoriaVM
    {
        public Articulo Articulo { get; set; }
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }

    }
}
