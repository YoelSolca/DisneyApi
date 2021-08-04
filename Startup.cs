



using AutoMapper;
using DisneyApi.Entities;
using DisneyApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;

namespace DisneyApi
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
            //Defino la conexion con la base de datos
            var connection = Configuration.GetConnectionString("CruzRojaDB");
            services.AddDbContextPool<Context>(options => options.UseSqlServer(connection));
            services.AddScoped <IRepository<Personaje>, PersonajeRepository>();
            services.AddScoped<IRepository<PeliculaSerie>, PeliculaSerieRepository>();

            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
            })

            .AddNewtonsoftJson(setupAction =>
                  {
                      setupAction.SerializerSettings.ContractResolver =
                          new CamelCasePropertyNamesContractResolver();
                  });



            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
