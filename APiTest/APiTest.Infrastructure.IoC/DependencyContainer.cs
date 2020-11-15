using APiTest.Data.Repositories;
using APiTest.Data.Repositories.Intefaces;
using APiTest.Negocio.Services;
using APiTest.Negocio.Services.Interface;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace APiTest.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICityServices, CityServices>();
            services.AddTransient<ICityRepository, CityRepository>();

        }

    }
}
