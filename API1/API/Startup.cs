using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Aplicacao;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            Cross.IOC.IOCManager.Register(services);
            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.AddSwaggerGen(_ =>
            {
                _.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Desafio",
                        Description = "",
                        Version = "v1"                        
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(_ => { _.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Softplan"); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.Run(async context => {
                context.Response.Redirect("swagger/index.html");
            });
        }
    }
}