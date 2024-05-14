using Domain.Common;
using System.Text.Json;

namespace Core.Candidates.Models
{
    public class CandidateResponse
    {
        /// <summary>
        /// Type of response expected from the question: Numeric, Date, Dropdown, Patagraph...
        /// </summary>
        public required QuestionType Type { get; set; }

        /// <summary>
        /// Question to be answered
        /// </summary>
        public required string Question { get; set; }

        /// <summary>
        /// JSON element corresponding to the question type. Array, Number, Date or String.
        /// </summary>
        public required JsonElement Response { get; set; }
    }
}
