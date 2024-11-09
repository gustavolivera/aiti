using Domain.Domain;
using Domain.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sistema.Models;
using Sistema.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(string Login, string Senha) {
            bool falha = false;
            if (string.IsNullOrWhiteSpace(Login))
            {
                ModelState.AddModelError("Login", "Usuário inválido");
                falha = true;
            }

            if (string.IsNullOrWhiteSpace(Senha))
            {
                ModelState.AddModelError("Senha", "Senha incorreta");
                falha = true;
            }

            if (falha) { 
            return View();
            }

            Usuario usuario = new Usuario().Entrar(_context, Login, Senha);

            if(usuario != null)
            {
                new ServiceCookies().Login(HttpContext, usuario);
                return RedirectToAction("Create", "Chamado");
            }
            else
            {
                return View();
            }
		}

    }
}
