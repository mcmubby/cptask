using Core.Candidates.Models;

namespace Core.Candidates.Interfaces
{
    public interface IApplicationService
    {
        Task CreateProgramApplication(CreateApplicationRequest request);
    }
}
