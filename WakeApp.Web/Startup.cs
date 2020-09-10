using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WakeApp.Core;
using WakeApp.Services;
using WakeApp.Web.Extensions;

namespace WakeApp.Web
{
    public class Startup
    {
        private ILocalEndPoint LocalEndPoint { get; }

        public Startup(IConfiguration configuration)
        {
            LocalEndPoint = configuration.GetLocalEndPoint();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IWolService, WolService>();
            services.AddTransient(e => LocalEndPoint);
            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
