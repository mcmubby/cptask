using Core.Candidates.Interfaces;
using Core.Candidates.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public CandidateController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost("/apply")]
        public async Task<ActionResult> CreateApplication(CreateApplicationRequest request)
        {
            try
            {
                await _applicationService.CreateProgramApplication(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
