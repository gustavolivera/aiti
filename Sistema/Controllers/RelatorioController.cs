using Domain.Domain;
using Domain.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sistema.Controllers
{
    [Authorize(Roles = "Tecnologia")]
    public class RelatorioController : Controller
    {
        private readonly Context _context;

        public RelatorioController(Context context)
        {
            this._context = context;
        }

        // GET: RelatorioController
        public ActionResult Index()
        {
            Chamado chamado = new Chamado();
            List<Chamado> chamados = chamado.BuscarTodos(_context).Where(c => c.Status == "Relatorio").ToList();
            var viewModel = new RelatorioViewModel
            {
                Chamados = chamados
            };
            return View(viewModel);
        }

        // GET: RelatorioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RelatorioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RelatorioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: RelatorioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RelatorioController/Edit/5
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

        // GET: RelatorioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RelatorioController/Delete/5
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
