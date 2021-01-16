using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Resuelve_prueba_ing_backend
{
    public class Startup
    {
        public static Dictionary<string,Equipo> Equipos { set; get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            Equipos= new Dictionary<string, Equipo>();
            List<string> Errores= new List<string>();

            /* -------- Valores por default de los equipos rojo y azul -------- */

            Equipo EquipoRojo = new Equipo();
            EquipoRojo.Nombre="rojo";
            /* ------ Niveles por default --------- */
            EquipoRojo.AgregarNivel(new Nivel(){nivel="A",GolMes=5 },out Errores);
            EquipoRojo.AgregarNivel(new Nivel(){nivel="B",GolMes=10 },out Errores);
            EquipoRojo.AgregarNivel(new Nivel(){nivel="C",GolMes=15 },out Errores);
            EquipoRojo.AgregarNivel(new Nivel(){nivel="Cuauh",GolMes=20 },out Errores);
            /* ------------------------------------ */
            Equipos.Add("rojo",EquipoRojo);

            Equipo EquipoAzul = new Equipo();
            EquipoAzul.Nombre="azul";
            /* ------ Niveles por default --------- */
            EquipoAzul.AgregarNivel(new Nivel(){nivel="A",GolMes=5 },out Errores);
            EquipoAzul.AgregarNivel(new Nivel(){nivel="B",GolMes=10 },out Errores);
            EquipoAzul.AgregarNivel(new Nivel(){nivel="C",GolMes=15 },out Errores);
            EquipoAzul.AgregarNivel(new Nivel(){nivel="Cuauh",GolMes=20 },out Errores);
            /* ------------------------------------ */
            Equipos.Add("azul",EquipoAzul);

            /* ---------------------------------------------------------------- */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
