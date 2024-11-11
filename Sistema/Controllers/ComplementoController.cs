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
    public class ComplementoController : Controller
    {
        private readonly Context _context;

        public ComplementoController(Context context)
        {
            _context = context;
        }

        // GET: ComplementoController
        public ActionResult Index()
        {
            List<Motivo> Motivos = new Motivo().BuscarTodos(_context).ToList();

            var MotivosList = Motivos.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewBag.Motivos = MotivosList;

            Complemento complemento = new Complemento();
            List<Complemento> complementos = complemento.BuscarTodos(_context);
            var viewModel = new ComplementoViewModel
            {
                Complementos = complementos,
                NovoComplemento = new Complemento()
            };
            return View(viewModel);

            return View("Index");
        }

        // GET: ComplementoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComplementoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComplementoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComplementoViewModel complemento)
        {
            try
            {
                complemento.NovoComplemento.Salvar(_context);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComplementoController/Edit/5
        public ActionResult Edit(int id)
        {
            List<Motivo> Motivos = new Motivo().BuscarTodos(_context).ToList();

            var MotivosList = Motivos.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewBag.Motivos = MotivosList;
            Motivo motivos = new Motivo().BuscarPorId(_context, id);

            return View("Index");
        }

        // POST: ComplementoController/Edit/5
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

        // GET: ComplementoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComplementoController/Delete/5
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
