using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEF6.Models
{
    public class Articulo
    {
        [Key]
        public int Articulo_Id { get; set; }

        [Required(ErrorMessage ="El título es obligatorio")]
        [Column("titulo")]
        [MaxLength(20)]
        [Display(Name = "Titulo del artículo")]
        public string TituloArticulo { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500, ErrorMessage = "Solo se admiten 500 caracteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Range(0.1, 5.0)]
        [Display(Name = "Calificación")]
        public double Calificacion { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [ForeignKey("Categoria")]
        public int Categoria_Id { get; set; }

        [Display(Name = "Categoría")]
        public Categoria Categoria { get; set; }

        //Relacion muchos a muchos
        public ICollection<ArticuloEtiqueta> articuloEtiquetas { get; set; }
    }
}
