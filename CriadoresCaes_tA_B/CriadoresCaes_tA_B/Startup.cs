using CriadoresCaes_tA_B.Data;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriadoresCaes_tA_B {
   public class Startup {
      public Startup(IConfiguration configuration) {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services) {

         // uso de vars. de sess�o
         services.AddDistributedMemoryCache();
         services.AddSession(options => {
            options.IdleTimeout = TimeSpan.FromSeconds(100);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
         });

         // definir qual a classe que representa a Base de Dados
         // e especifica qual o motor (engine) que manipula a base de dados
         // Especifica, tamb�m, onde est� a defini��o da localiza��o da Base de Dados - ver ficheiro 'appSettings.json'
         services.AddDbContext<CriadoresCaesDB>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


         services.AddDatabaseDeveloperPageExceptionFilter();


         // deixo de referir 'IdentityUser' e passo a usar 'ApplicationUser'
         services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
             .AddEntityFrameworkStores<CriadoresCaesDB>();
         services.AddControllersWithViews();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
         if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
         }
         else {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
         }
         app.UseHttpsRedirection();
         app.UseStaticFiles();

         app.UseRouting();

         // permitir o uso de vars. de sess�o
         app.UseSession();

         app.UseAuthentication();
         app.UseAuthorization();

         app.UseEndpoints(endpoints => {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapRazorPages();
         });
      }
   }
}
