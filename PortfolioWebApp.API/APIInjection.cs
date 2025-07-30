using PortfolioWebApp.API.Controllers;
using System.Reflection;

namespace PortfolioWebApp.API
{
    public static class APIInjection
    {
        public static IServiceCollection AddAPIs(this IServiceCollection services)
        {
            services.AddMvc().AddApplicationPart(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
