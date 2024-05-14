using Core.Candidates.Interfaces;
using Core.Candidates.Services;
using Core.Employers.Interfaces;
using Core.Employers.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class Dependencies
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IOfferingService, OfferingService>();
        }
    }
}
