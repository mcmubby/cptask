namespace Domain.Employers
{
    public class ProgramOffering
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required  List<ProgramQuestion> PersonalInformation { get; set; }
        public List<ProgramQuestion>? ProgramQuestions { get; set; }

        // Ideal fields but out of scope
        //public string? EmployerId { get; set; }
        //public bool IsActive { get; set; }
    }
}
