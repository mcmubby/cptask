using Domain.Candidates;

namespace Core.Persistence.Interfaces
{
    public interface IProgramApplicationRepository
    {
        Task<ProgramApplication> CreateApplicationAsync(ProgramApplication application);
    }
}
