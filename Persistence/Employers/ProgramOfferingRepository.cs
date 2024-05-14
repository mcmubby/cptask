using Domain.Employers;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;

namespace Persistence.Employers
{
    public class ProgramOfferingRepository
    {
        private readonly IConfiguration _configuration;
        private readonly Container _offeringsContainer;

        public ProgramOfferingRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            _configuration = configuration;

            var dbName = _configuration["DbSettings:DbName"];
            var containerName = "Offerings";
            _offeringsContainer = cosmosClient.GetContainer(dbName, containerName);
        }

        public async Task<ProgramOffering> CreateProgramAsync(ProgramOffering program)
        {
            var response = await _offeringsContainer.CreateItemAsync(program);
            return response.Resource;
        }

        public async Task<ProgramOffering> GetProgramByIdAsync(string programId)
        {
            var query = _offeringsContainer.GetItemLinqQueryable<ProgramOffering>()
            .Where(o => o.Id == programId)
            .Take(1)
            .ToQueryDefinition();

            var response = await _offeringsContainer.GetItemQueryIterator<ProgramOffering>(query).ReadNextAsync();
            return response.FirstOrDefault();
        }

        public async Task<ProgramOffering> UpdateProgramAsync(ProgramOffering program)
        {
            var response = await _offeringsContainer.UpsertItemAsync(program);
            return response.Resource;
        }
    }
}
