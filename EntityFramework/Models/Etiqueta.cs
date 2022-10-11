using System.ComponentModel.DataAnnotations;

namespace CursoEF6.Models
{
    public class Etiqueta
    {
        [Key]
        public int EtiquetaId { get; set; }

        [Display(Name = "Título de etiqueta")]
        public string Titulo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        //Para relacion de muchos a muchos
        public ICollection<ArticuloEtiqueta> articuloEtiquetas { get; set; }
    }
}
