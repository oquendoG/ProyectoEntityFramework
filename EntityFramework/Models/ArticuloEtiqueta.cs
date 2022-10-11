
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEF6.Models
{
    public class ArticuloEtiqueta
    {
        [ForeignKey("Articulo")]
        public int Articulo_Id { get; set; }
        public Articulo Articulo { get; set; }

        [ForeignKey("Etiqueta")]
        public int EtiquetaId { get; set; }
        public Etiqueta Etiqueta { get; set; }
    }
}
