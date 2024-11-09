using Domain.EF;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Instancia o contexto como um serviço, ou seja, o asp.core ficará responsável
            //por instanciar o Context
            services.AddDbContext<Context>(options =>
                options.
                    //Implementa o conceito de LazyLoading dos objetos
                    UseLazyLoadingProxies().
                    //Define SQL Server como banco de dados e busca URL de conexão no AppSettings
                    UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddControllersWithViews();

            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(options =>
                {

                    //401 Unauthorized
                    options.LoginPath = new PathString("/Home/Login");

                    options.AccessDeniedPath = new PathString("/Home/Login");
                });
            //Incluir serviço de Sessão
            services.AddSession();
            //Incluir serviço de Authoruzação
            services.AddAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //Instancia serviço de sessão
            app.UseSession();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = HttpOnlyPolicy.Always
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Chamado}/{action=Create}/{id?}");
            });
        }
    }
}
