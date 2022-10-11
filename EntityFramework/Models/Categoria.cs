using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEF6.Models
{
    public class Categoria
    {
        [Key]
        ////No se genera el id automáticamente
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Categoria_Id { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[Null]")]
        [Required]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        public bool Active { get; set; }

        public List<Articulo> Articulo { get; set; }
    }
}
