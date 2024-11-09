using Domain.Domain;
using Domain.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Sistema.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private Context _context;

        public UsuarioController(Context context)
        {
            _context = context;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            Usuario usuario = new Usuario();
            List<Usuario> usuarios =  
                usuario.BuscarTodos(_context);
            return View(usuarios);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {

                Dictionary<string, string> erros = 
                    usuario.Salvar(_context);

                if (erros.Count == 0)
                {
                    //Salvo com sucesso, sem erros
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var erro in erros)
                    {
                        ModelState.AddModelError(erro.Key, erro.Value);
                    }
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario usuario = new Usuario().BuscarPorId(_context, id);
            return View(usuario);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuarioAntigo)
        {
            try
            {
                Usuario usuarioAlterado =
                    new Usuario().BuscarPorId(_context, usuarioAntigo.Id);
                
                usuarioAlterado.Login = usuarioAntigo.Login;

                usuarioAlterado.Alterar(_context);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario usuario = new Usuario().BuscarPorId(_context, id);
            return View(usuario);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                Usuario usuario = new Usuario().
                    BuscarPorId(_context, id);

                usuario.Remover(_context);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
