using Domain.Domain;
using Domain.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Sistema.Controllers
{
    public class ChamadoController : Controller
    {
        private readonly Context _context;

        public ChamadoController(Context context)
        {
            _context = context;
        }


        // GET: ChamadoController
        public ActionResult Index()
        {
            List<Chamado> chamados = new Chamado().BuscarTodos(_context).ToList();

            return View(chamados);
        }

        // GET: ChamadoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize]
        // GET: ChamadoController/Create
        public ActionResult Create()
        {
            List<Motivo> Motivos = new Motivo().BuscarTodos(_context).ToList();

            var MotivosList = Motivos.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewBag.Motivos = MotivosList;

            List<Complemento> Complementos = new Complemento().BuscarTodos(_context).ToList();

            var ComplementosList = Complementos.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString(), }).ToList();
            ViewBag.Complementos = ComplementosList;
            var viewModel = new ChamadoViewModel
            {
                Motivos = Motivos,
                Complementos = Complementos
            };


            return View(viewModel);
        }

        // POST: ChamadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChamadoViewModel viewmodel)
        {
            try
            {
                viewmodel.NovoChamado.Status = "Aberto";
                viewmodel.NovoChamado.DataHora_inicio = DateTime.UtcNow;

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtém o ID do usuário logado
                                                                             // Converte o ID do usuário para inteiro
                int usuarioId = int.Parse(userId);

                // Consulta o banco de dados para obter o PessoaId associado ao UsuarioId
                var pessoa = _context.Pessoas.FirstOrDefault(p => p.UsuarioId == usuarioId);

                if (pessoa != null)
                {
                    // Atribui o PessoaId ao chamado
                    viewmodel.NovoChamado.PessoaId = pessoa.Id;
                }

                viewmodel.NovoChamado.Salvar(_context);
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChamadoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChamadoController/Edit/5
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

        // GET: ChamadoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChamadoController/Delete/5
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
