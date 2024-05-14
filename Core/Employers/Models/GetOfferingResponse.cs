using Domain.Employers;

namespace Core.Employers.Models
{
    public class GetOfferingResponse
    {
        public required string ProgramId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required List<ProgramQuestion> PersonalInformation { get; set; }
        public List<ProgramQuestion>? ProgramQuestions { get; set; }
    }
}
