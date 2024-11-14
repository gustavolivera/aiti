using Domain.Domain;
using Domain.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema.Models;
using System.Collections.Generic;

namespace Sistema.Controllers
{
    [Authorize(Roles = "Tecnologia")]
    public class MotivoController : Controller
    {
        private readonly Context _context;

        public MotivoController(Context context)
        {
            this._context = context;
        }
        
        // GET: MotivoController
        public ActionResult Index()
        {
            Motivo motivo = new Motivo();
            List<Motivo> motivos = motivo.BuscarTodos(_context);
            var viewModel = new MotivoViewModel
            {
                Motivos = motivos,
                NovoMotivo = new Motivo()
            };
            return View(viewModel);
        }

        // GET: MotivoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MotivoController/Create
        public ActionResult Create()
        {
            return View("Index");
        }

        // POST: MotivoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MotivoViewModel viewmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewmodel.NovoMotivo.Salvar(_context);
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

        // GET: MotivoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MotivoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int id, Motivo model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var motivoToUpdate = _context.Motivos.Find(id);
                if (motivoToUpdate == null)
                {
                    return NotFound();
                }

                motivoToUpdate.Nome = model.Nome;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: MotivoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MotivoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Motivo motivo = new Motivo().BuscarPorId(_context, id);
                    motivo.Remover(_context);
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
