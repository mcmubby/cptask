using Domain.Employers;

namespace Core.Persistence.Interfaces
{
    public interface IProgramOfferingRepository
    {
        Task<ProgramOffering> CreateProgramAsync(ProgramOffering program);
        Task<ProgramOffering> GetProgramByIdAsync(string programId);
        Task<ProgramOffering> UpdateProgramAsync(ProgramOffering program);
    }
}
