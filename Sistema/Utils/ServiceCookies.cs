﻿using Domain.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Sistema.Utils
{
    public class ServiceCookies
    {
        public void Login(HttpContext ctx, Usuario usuario)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, usuario.Login), // Adiciona o nome de usuário
        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()) // Adiciona o ID do usuário como NameIdentifier
    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddHours(8), // Expira em 8 horas
                IssuedUtc = DateTime.UtcNow
            };

            ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties).Wait();
        }


        public void Logout(HttpContext ctx)
        {
            ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

    }
}
