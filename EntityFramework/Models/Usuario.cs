using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEF6.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name="Dirección del usuario")]
        public string Direccion { get; set; }

        [ForeignKey("DetalleUsuario")]
        public int? DetalleUsuario_Id { get; set; }

       
        public DetalleUsuario DetalleUsuario { get; set; }

    }
}
