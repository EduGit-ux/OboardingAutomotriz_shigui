using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OboardingAutomotriz.Infraestructure.Context;
using OnboardingAutomotriz.Domain.Interfaces;
using OnboardingAutomotriz.Repository.Servicio;

namespace OboardingAutomotriz
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
            #region Conecion BBDD
            services.AddDbContext<BBDDOnboardingContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("cxDBConexion")));
            #endregion

            #region INFRASTRUCTURE
            services.AddScoped<ICargarDatos, SCargarDatos>();
            services.AddScoped<ICliente, SCliente>();
            services.AddScoped<IPatio, SPatio>();
            services.AddScoped<IAsigancionClientePatio, SAsignarClientePatio>();
            services.AddScoped<IVehiculo, SVehiculo>();
            services.AddScoped<ISolicitudCredito, SSolicitudCredito>();
            services.AddScoped<IMarca, SMarca>();
            services.AddScoped<IEjecutivo, SEjecutivo>();
            #endregion


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OboardingAutomotriz", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OboardingAutomotriz v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
