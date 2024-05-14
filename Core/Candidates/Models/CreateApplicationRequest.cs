namespace Core.Candidates.Models
{
    public class CreateApplicationRequest
    {
        public required string ProgramId { get; set; }
        public required List<CandidateResponse> PersonalInformation { get; set; }
        public List<CandidateResponse>? ProgramResponses { get; set; }
    }
}
