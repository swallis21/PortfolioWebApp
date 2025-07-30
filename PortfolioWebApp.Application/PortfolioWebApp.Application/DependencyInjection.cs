using Microsoft.Extensions.DependencyInjection;
using PortfolioWebApp.Application.Configuration;
using PortfolioWebApp.Domain.Models.Singletons;
using System.Reflection;

namespace PortfolioWebApp.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddAutoMapper(AutoMapperConfig.MapperConfig);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddSingleton<MusicData>();
            return services;
        }
    }
}
