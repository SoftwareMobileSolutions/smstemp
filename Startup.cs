using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using smstemp.Data;
using smstemp.Interfaces;
using smstemp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smstemp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTelerikBlazor();
            services.AddControllersWithViews();

            services.AddScoped<Blazor_IListados, Blazor_ListadosService>();
            services.AddScoped<Blazor_IrpteAlertasDiarias, Blazor_rpteAlertasDiariasService>();
            services.AddScoped<Blazor_IEstadoActual, Blazor_EstadoActualService>();
            services.AddScoped<Blazor_IAdminAlarmas, Blazor_AdminAlarmasService>();
            services.AddScoped<Blazor_IrpteHistorico, Blazor_rpteHistoricoService>();
            services.AddScoped<Blazor_IrpteMensual, Blazor_rpteMensualService>();

            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();

            services.AddSingleton(new SqlCnConfigMain(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDistributedMemoryCache();

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();
            /*
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {*/
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
           // }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
