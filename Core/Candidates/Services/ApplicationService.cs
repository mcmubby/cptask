using Core.Candidates.Interfaces;
using Core.Candidates.Models;
using Core.Persistence.Interfaces;
using Domain.Candidates;
using Domain.Common;
using System.Text.Json;

namespace Core.Candidates.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IProgramApplicationRepository _repository;

        public ApplicationService(IProgramApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateProgramApplication(CreateApplicationRequest request)
        {
            var personalInformationResponse = DeserializeCandidateResponse(request.PersonalInformation);
            var programResponse = request.ProgramResponses != null ? DeserializeCandidateResponse(request.ProgramResponses) : null;
            

            var application = new ProgramApplication
            {
                Id = Guid.NewGuid().ToString(),
                ProgramId = request.ProgramId,
                ProgramResponses = programResponse,
                PersonalInformation = personalInformationResponse
            };

            await _repository.CreateApplicationAsync(application);
        }

        private static List<QuestionResponse> DeserializeCandidateResponse(List<CandidateResponse> responses)
        {
            var result  = new List<QuestionResponse>();

            foreach (var response in responses)
            {
                switch (response.Type)
                {
                    case QuestionType.Paragraph:
                    case QuestionType.MultiChoice:
                    case QuestionType.Dropdown:
                        if (response.Response.ValueKind == JsonValueKind.String)
                            result.Add(new QuestionResponse { Question = response.Question, Type = response.Type, Response = response.Response.Deserialize<string>() });
                        else
                            result.Add(new QuestionResponse { Question = response.Question, Type = response.Type, Response = response.Response.Deserialize<List<string>>() });
                        break;

                    case QuestionType.YesNo:
                        result.Add(new QuestionResponse { Question = response.Question, Type = response.Type, Response = response.Response.Deserialize<bool>() });
                        break;

                    case QuestionType.Date:
                        result.Add(new QuestionResponse { Question = response.Question, Type = response.Type, Response = response.Response.Deserialize<DateTime>() });
                        break;

                    case QuestionType.Number:
                        result.Add(new QuestionResponse { Question = response.Question, Type = response.Type, Response = response.Response.Deserialize<long>() });
                        break;

                    default:
                        break;
                }
            }

            return result;
        }


    }
}
