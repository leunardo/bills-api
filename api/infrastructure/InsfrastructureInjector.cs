using infrastructure.interfaces;
using infrastructure.repository;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructure
{
    public static class InfrastructureInjector
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IBusinessRuleRepository, BusinessRuleRepository>();
        }
    }
}