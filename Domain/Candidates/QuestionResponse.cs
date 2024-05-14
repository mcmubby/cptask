using Domain.Common;

namespace Domain.Candidates
{
    public class QuestionResponse
    {
        public required QuestionType Type { get; set; }
        public required string Question { get; set; }
        public required dynamic Response { get; set; }
    }
}
