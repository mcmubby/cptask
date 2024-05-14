using Domain.Candidates;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace Persistence.Candidates
{
    public class ProgramApplicationRepository
    {
        private readonly IConfiguration _configuration;
        private readonly Container _applicationsContainer;

        public ProgramApplicationRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            _configuration = configuration;

            var dbName = _configuration["DbSettings:DbName"];
            var containerName = "Applications";
            _applicationsContainer = cosmosClient.GetContainer(dbName, containerName);
        }

        public async Task<ProgramApplication> CreateApplicationAsync(ProgramApplication application)
        {
            var response = await _applicationsContainer.CreateItemAsync(application);
            return response.Resource;
        }
    }
}
