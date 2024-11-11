using Domain.Domain;
using Domain.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sistema.Controllers
{
    public class FuncaoController : Controller
    {
        private readonly Context _context;

        public FuncaoController(Context context)
        {
            _context = context;
        }

        // GET: FuncaoController
        public ActionResult Index()
        {
            List<Setor> Setores = new Setor().BuscarTodos(_context).ToList();

            var SetorList = Setores.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewBag.Setores = SetorList;

            Funcao funcao = new Funcao();
            List<Funcao> funcoes = funcao.BuscarTodos(_context);
            var viewModel = new FuncaoViewModel
            {
                Funcoes = funcoes,
                NovaFuncao = new Funcao()
            };
            return View(viewModel);
        }

        // GET: FuncaoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FuncaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FuncaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FuncaoViewModel funcao)
        {
            try
            {
                funcao.NovaFuncao.Salvar(_context);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FuncaoController/Edit/5
        public ActionResult Edit(int id)
        {
            List<Setor> Setores = new Setor().BuscarTodos(_context).ToList();

            var SetorList = Setores.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewBag.Setores = SetorList;

            Setor setor = new Setor().BuscarPorId(_context, id);
            return View();
        }

        // POST: FuncaoController/Edit/5
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

        // GET: FuncaoController/Delete/5
        public ActionResult Delete()
        {
            return View("Index");
        }

        // POST: FuncaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Funcao funcao = new Funcao().BuscarPorId(_context, id);
                    funcao.Remover(_context);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Index");
                }
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
