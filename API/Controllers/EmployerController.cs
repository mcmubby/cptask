using Core.Employers.Interfaces;
using Core.Employers.Models;
using Core.Exceptions;
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

        /// <summary>
        /// Create a new program offering
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/program")]
        [ProducesResponseType(typeof(CreateOfferingResponse), 201)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CreateOfferingResponse>> CreateProgramOffering(CreateOfferingRequest request)
        {
            try
            {
                var result = await _offeringService.CreateProgramOfferingAsync(request);
                return CreatedAtAction(nameof(GetProgramOffering), new { id = result.Id }, result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Update an existing program
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("/program")]
        [ProducesResponseType(typeof(CreateOfferingResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CreateOfferingResponse>> UpdateProgramOffering(UpdateOfferingRequest request)
        {
            try
            {
                var result = await _offeringService.UpdateProgramOfferingAsync(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                if (e is NotFoundException) { return NotFound(); }

                return StatusCode(500, "Error updating program, please try again later.");
            }
        }

        /// <summary>
        /// Get a specific program offering
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/program/{id}")]
        [ProducesResponseType(typeof(CreateOfferingResponse),200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CreateOfferingResponse>> GetProgramOffering(string id)
        {
            try
            {
                var result = await _offeringService.GetProgramOfferingAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                if(e is NotFoundException) { return NotFound(); }

                return StatusCode(500, "Error fetching program, please try again later.");
            }
        }
    }
}
