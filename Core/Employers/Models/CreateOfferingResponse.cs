using Domain.Employers;

namespace Core.Employers.Models
{
    public class CreateOfferingResponse
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required List<ProgramQuestion> PersonalInformation { get; set; }
        public List<ProgramQuestion>? ProgramQuestions { get; set; }
    }
}
