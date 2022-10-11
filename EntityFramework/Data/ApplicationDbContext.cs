using CursoEF6.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoEF6.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones)
        {

        }

        //Agregando los modelos
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<DetalleUsuario> DetalleUsuarios { get; set; }
        public DbSet<Etiqueta> Etiquetas { get; set; }
        public DbSet<ArticuloEtiqueta> ArticuloEtiquetas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticuloEtiqueta>()
                .HasKey(ae => new {ae.EtiquetaId, ae.Articulo_Id});

            var categoria8 = new Categoria() 
            { Categoria_Id = 21, Nombre = "Categoria 8", FechaCreacion = new DateTime(2022, 01, 02), Active = true };
            var categoria9 = new Categoria() 
            { Categoria_Id = 22, Nombre = "Categoria 9", FechaCreacion = new DateTime(2022, 05, 12), Active = true };

            modelBuilder.Entity<Categoria>().HasData(new Categoria[] { categoria8});
            base.OnModelCreating(modelBuilder);

        }   
    }
}
