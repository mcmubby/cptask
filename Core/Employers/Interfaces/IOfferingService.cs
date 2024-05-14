using Core.Employers.Models;

namespace Core.Employers.Interfaces
{
    public interface IOfferingService
    {
        Task<CreateOfferingResponse> CreateProgramOfferingAsync(CreateOfferingRequest request);
        Task<CreateOfferingResponse> UpdateProgramOfferingAsync(UpdateOfferingRequest request);
        Task<GetOfferingResponse> GetProgramOfferingAsync(string offeringId);
    }
}
