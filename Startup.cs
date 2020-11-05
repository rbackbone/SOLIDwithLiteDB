using AVDharma.LeilaoOnline.WebApp.Dados;
using AVDharma.LeilaoOnline.WebApp.Dados.LiteDB;
using AVDharma.LeilaoOnline.WebApp.Models;
using AVDharma.LeilaoOnline.WebApp.Services;
using AVDharma.LeilaoOnline.WebApp.Services.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AVDharma.LeilaoOnline.WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers().AddControllersAsServices();

            // aqui indico ao AspNetCore como resolver 
            // as instâncias das Interfaces de acesso a dados
            //---------------------------------------------------

            services.AddTransient<ICategoriaDao, CategoriaDaoComLiteDB>();
            services.AddTransient<ILeilaoDao, LeilaoDaoComLiteDB>();
            services.AddTransient<IAdminService, ArquivamentoAdminService>();
            services.AddTransient<IProdutoService, DefaultProdutoService>();

            services.AddSingleton<LiteDbContext>();


            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(options => 
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePagesWithRedirects("/Home/StatusCode/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
