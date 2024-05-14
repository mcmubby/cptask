using Core.Persistence.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Candidates;
using Persistence.Employers;

namespace Persistence
{
    public static class Dependencies
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton((provider) =>
            {
                var uri = configuration["DbSettings:Uri"];
                var dbName = configuration["DbSettings:DbName"];
                var primaryKey = configuration["DbSettings:PrimaryKey"];

                var cosmosClientOptions = new CosmosClientOptions { ApplicationName = dbName };

                var cosmosClient = new CosmosClient(uri, primaryKey, cosmosClientOptions);
                //cosmosClient.CreateDatabaseIfNotExistsAsync(uri).Wait();

                return cosmosClient;
            });

            services.AddScoped<IProgramApplicationRepository, ProgramApplicationRepository>();
            services.AddScoped<IProgramOfferingRepository, ProgramOfferingRepository>();

        }
    }
}
