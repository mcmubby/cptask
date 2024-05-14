using Domain.Common;
using System.Text.Json;

namespace Core.Candidates.Models
{
    public class CandidateResponse
    {
        public required QuestionType Type { get; set; }
        public required string Question { get; set; }
        public required JsonElement Response { get; set; }
    }
}
