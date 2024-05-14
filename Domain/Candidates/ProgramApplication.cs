using Newtonsoft.Json;

namespace Domain.Candidates
{
    public class ProgramApplication
    {
        [JsonProperty("id")]
        public required string Id { get; set; }
        public required string ProgramId { get; set; }
        public required List<QuestionResponse> PersonalInformation { get; set; }
        public List<QuestionResponse>? ProgramResponses { get; set; }

        // Ideal fields but out of task scope
        //public string? CandidateId { get; set; }
        //public string? Status { get; set; }
    }
}
