using Domain.Common;
using System.Text.Json.Serialization;

namespace Domain.Employers
{
    public class ProgramQuestion
    {
        public required QuestionType Type { get; set; }
        public required string Question { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Choice { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? MaxChoice { get; set; }
    }
}
