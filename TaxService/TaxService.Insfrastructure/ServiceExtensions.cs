using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxService.Application.Interfaces;

namespace TaxService.Insfrastructure
{
    public static class ServiceExtensions
    {
        private const string DefaultServiceName = "t1";
        private const string TaxJarServiceName = "t2";
        public static void RegisterInfrastructerServices(this IServiceCollection services, IConfiguration configuration)
        {
            var clientTier = "t2"; //get client from azure keyvault
            services.AddScoped<IRepository>((serviceProvider) =>
            {
                if (clientTier == DefaultServiceName)
                {
                    return new TaxDefaultService();
                }

                if (clientTier == TaxJarServiceName)
                {
                    return new TaxJarApiService(configuration);
                }
                return new TaxJarApiService(configuration);
            });
        }
    }
}
