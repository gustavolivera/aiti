using Domain.Domain;
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
        public void Login (HttpContext ctx, Usuario usuario){
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, usuario.Login));

            var claimIdentity =
                new ClaimsPrincipal(
                    new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme)
                    );
            
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.Now.AddHours(8),
                IssuedUtc = DateTime.Now
            };

            ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                claimIdentity, authProperties);
        }

        public void Logout(HttpContext ctx)
        {
            ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

    }
}
