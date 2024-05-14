namespace Core.Candidates.Models
{
    /// <summary>
    /// Application model
    /// </summary>
    public class CreateApplicationRequest
    {
        /// <summary>
        /// Id of the program being applied for
        /// </summary>
        public required string ProgramId { get; set; }

        /// <summary>
        /// List of responses under personal information category
        /// </summary>
        public required List<CandidateResponse> PersonalInformation { get; set; }

        /// <summary>
        /// List of responses under program questions category
        /// </summary>
        public List<CandidateResponse>? ProgramResponses { get; set; }
    }
}
