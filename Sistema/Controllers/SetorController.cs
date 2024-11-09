using Domain.Domain;
using Domain.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema.Models;
using System.Collections.Generic;

namespace Sistema.Controllers
{
    public class SetorController : Controller
    {
        private readonly Context _context;
        public SetorController(Context context)
        {
            this._context = context;
        }

        // GET: SetorController
        public ActionResult Index()
        {
            Setor setor = new Setor();
            List<Setor> setores = setor.BuscarTodos(_context);
            var viewModel = new SetorViewModel
            {
                Setores = setores,
                NovoSetor = new Setor()
            };
            return View(viewModel);
        }

        // GET: SetorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SetorController/Create
        public ActionResult Create()
        {
            return View("Index");
        }

        // POST: SetorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SetorViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.NovoSetor.Salvar(_context);
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

        // GET: SetorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SetorController/Edit/5
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

        // GET: SetorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SetorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
