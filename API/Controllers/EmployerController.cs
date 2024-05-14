using Core.Employers.Interfaces;
using Core.Employers.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IOfferingService _offeringService;

        public EmployerController(IOfferingService offeringService)
        {
            _offeringService = offeringService;
        }

        [HttpPost("/program")]
        public async Task<ActionResult<CreateOfferingResponse>> CreateProgramOffering(CreateOfferingRequest request)
        {
            try
            {
                var result = await _offeringService.CreateProgramOfferingAsync(request);
                return Created(result.Id, result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("/program")]
        public async Task<ActionResult<CreateOfferingResponse>> UpdateProgramOffering(UpdateOfferingRequest request)
        {
            try
            {
                var result = await _offeringService.UpdateProgramOfferingAsync(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/program/{id}")]
        public async Task<ActionResult<CreateOfferingResponse>> GetProgramOffering(string id)
        {
            try
            {
                var result = await _offeringService.GetProgramOfferingAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
