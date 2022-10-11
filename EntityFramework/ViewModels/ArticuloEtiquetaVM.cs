﻿using CursoEF6.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CursoEF6.ViewModels
{
    public class ArticuloEtiquetaVM
    {
        public ArticuloEtiqueta ArticuloEtiqueta { get; set; }

        public Articulo Articulo { get; set; }

        public IEnumerable<ArticuloEtiqueta> ListaArticuloEtiquetas { get; set; }

        public IEnumerable<SelectListItem> ListaEtiquetas { get; set; }
    }
}
