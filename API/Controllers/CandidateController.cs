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

        /// <summary>
        /// Submit application for a program/job offering
        /// </summary>
        /// <param name="request">The response to the program questions</param>
        [HttpPost("/apply")]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> CreateApplication(CreateApplicationRequest request)
        {
            try
            {
                await _applicationService.CreateProgramApplication(request);
                return Created();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
