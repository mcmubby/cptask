using Domain.Employers;

namespace Core.Employers.Models
{
    public class CreateOfferingRequest
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool RequestPhone { get; set; }
        public bool RequestNationality { get; set; }
        public bool RequestCurrentResidence { get; set; }
        public bool RequestIDNumber { get; set; }
        public bool RequestGender { get; set; }
        public List<ProgramQuestion>? AdditionalPersonalInformation { get; set; }
        public List<ProgramQuestion>? ProgramQuestions { get; set; }

        // Ideal fields
        //public string EmployerId { get; set; }
    }
}
