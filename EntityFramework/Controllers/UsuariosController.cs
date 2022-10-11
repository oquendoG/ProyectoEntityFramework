using CursoEF6.Data;
using CursoEF6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CursoEF6.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext contexto;

        public UsuariosController(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

        public IActionResult Index()
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = contexto.Usuarios.Take(15).ToList();
            return View(usuarios);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                contexto.Usuarios.Add(usuario);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id is null)
            {
                return View();
            }

            var usuario = contexto.Usuarios.FirstOrDefault(user => user.Id == id);
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                contexto.Usuarios.Update(usuario);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Borrar(int id)
        {
            if (id == 0)
            {
                return View("Index");
            }

            var usuario = contexto.Usuarios.FirstOrDefault(user => user.Id == id);
            if (usuario is null)
            {
                return View("Index");
            }

            contexto.Usuarios.Remove(usuario);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return View();
            }
            var usuario = contexto.Usuarios
                .Include(user => user.DetalleUsuario).FirstOrDefault(user => user.Id == id);

            if (usuario is null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        public IActionResult AgregarDetalle(Usuario usuario)
        {
            if (usuario.DetalleUsuario.DetalleUsuario_Id == 0)
            {
                contexto.DetalleUsuarios.Add(usuario.DetalleUsuario);
                contexto.SaveChanges();

                var usuarioBD = contexto.Usuarios.FirstOrDefault(user => user.Id == usuario.Id);

                usuarioBD.DetalleUsuario_Id = usuario.DetalleUsuario.DetalleUsuario_Id;
                contexto.SaveChanges();


                return RedirectToAction("Index");
            }

            return View(usuario.DetalleUsuario);
        }

    }
}
