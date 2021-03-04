using Application.Interfaces;
using Aplicacao.Services;
using Core.Interfaces;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Core.Validation;

namespace Cross.IOC
{
    public class IOCManager
    {
        public static void Register(IServiceCollection services)
        {
            // Services
            services.AddScoped<IServiceCalculo, ServiceCalculo>();

            //Applications Services
            services.AddScoped<IAppServiceCalc, AppServiceCalc>();

            services.AddScoped<INotification, Notification>();

            // Services
            services.AddScoped<IServicoJuro, ServicoJuro>();

            //Applications Services
            services.AddScoped<IAppServiceJuro, AppServiceJuro>();

            


        }
    }
}
