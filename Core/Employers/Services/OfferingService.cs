using Core.Employers.Interfaces;
using Core.Employers.Models;
using Core.Exceptions;
using Core.Persistence.Interfaces;
using Domain.Common;
using Domain.Employers;

namespace Core.Employers.Services
{
    public class OfferingService : IOfferingService
    {
        private readonly IProgramOfferingRepository _repository;

        public OfferingService(IProgramOfferingRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateOfferingResponse> CreateProgramOfferingAsync(CreateOfferingRequest request)
        {
            var mandatoryFields = CreateMandatoryFields();

            var offering = new ProgramOffering
            {
                Id = Guid.NewGuid().ToString(),
                Title = request.Title,
                Description = request.Description,
                PersonalInformation = mandatoryFields,
                ProgramQuestions = request.ProgramQuestions
            };

            if (request.RequestPhone)
                offering.PersonalInformation.Add(new ProgramQuestion { Type = QuestionType.Number, Question = "Phone" });

            if (request.RequestNationality)
                offering.PersonalInformation.Add(new ProgramQuestion { Type = QuestionType.Dropdown, Question = "Nationality" });

            if (request.RequestCurrentResidence)
                offering.PersonalInformation.Add(new ProgramQuestion { Type = QuestionType.Dropdown, Question = "Current Residence" });

            if (request.RequestIDNumber)
                offering.PersonalInformation.Add(new ProgramQuestion { Type = QuestionType.Number, Question = "ID Number" });

            if (request.RequestIDNumber)
                offering.PersonalInformation.Add(new ProgramQuestion { Type = QuestionType.Date, Question = "Date of Birth" });

            if (request.RequestIDNumber)
                offering.PersonalInformation.Add(new ProgramQuestion { Type = QuestionType.Dropdown, Question = "Gender" });

            
            var response = await _repository.CreateProgramAsync(offering);

            return new CreateOfferingResponse
            {
                Id = response.Id,
                Title = response.Title,
                Description = response.Description,
                PersonalInformation = response.PersonalInformation,
                ProgramQuestions = response.ProgramQuestions
            };
        }

        public async Task<CreateOfferingResponse> UpdateProgramOfferingAsync(UpdateOfferingRequest request)
        {
            var offering = await _repository.GetProgramByIdAsync(request.Id) ?? throw new NotFoundException("Program");

            offering.PersonalInformation = request.PersonalInformation;
            offering.Description = request.Description;
            offering.Title = request.Title;
            offering.ProgramQuestions = request.ProgramQuestions;

            var response = await _repository.UpdateProgramAsync(offering);

            return new CreateOfferingResponse
            {
                Id = response.Id,
                Title = response.Title,
                Description = response.Description,
                PersonalInformation = response.PersonalInformation,
                ProgramQuestions = response.ProgramQuestions
            };
        }

        public async Task<GetOfferingResponse> GetProgramOfferingAsync(string offeringId)
        {
            var offering = await _repository.GetProgramByIdAsync(offeringId) ?? throw new NotFoundException("Program");

            return new GetOfferingResponse
            {
                ProgramId = offering.Id,
                Title = offering.Title,
                Description = offering.Description,
                PersonalInformation = offering.PersonalInformation,
                ProgramQuestions = offering.ProgramQuestions
            };
        }

        private static List<ProgramQuestion> CreateMandatoryFields()
        {
            List<ProgramQuestion> mandatoryFields = [
                new ProgramQuestion{Type = QuestionType.Paragraph, Question = "First Name"},
                new ProgramQuestion{Type = QuestionType.Paragraph, Question = "Last Name"},
                new ProgramQuestion{Type = QuestionType.Paragraph, Question = "Email"}
            ];

            return mandatoryFields;
        }
    }
}
