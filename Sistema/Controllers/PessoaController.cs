using Domain.Domain;
using Domain.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistema.Controllers
{
    public class PessoaController : Controller
    {
        private readonly Context _context;

        public PessoaController(Context context)
        {
            _context = context;
        }
        // GET: PessoaController
        public ActionResult Index()
        {
            List<Funcao> Funcoes = new Funcao().BuscarTodos(_context).ToList();

            var FuncaoList = Funcoes.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewBag.Funcoes = FuncaoList;
            return View();
        }

        // GET: PessoaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PessoaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PessoaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoa pessoa)
        {
            try
            {
                var usuario = new Usuario
                {
                    Login = pessoa.Email, // ou outro campo apropriado
                    Senha = pessoa.Senha, // Você pode gerar uma senha de forma mais segura
                };
                usuario.Salvar(_context);
                pessoa.UsuarioId = usuario.Id;
                pessoa.Salvar(_context);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: PessoaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PessoaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PessoaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
