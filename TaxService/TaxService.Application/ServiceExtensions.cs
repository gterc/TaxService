using Microsoft.Extensions.DependencyInjection;
using TaxService.Application.Interfaces;
using TaxService.Application.Operations;

namespace TaxService.Application
{
    public static class ServiceExtensions
    {
        public static void RegisterApplicationServices(this IServiceCollection service)
        {
            service.AddScoped<IService, TaxOpService>();
        }
    }
}