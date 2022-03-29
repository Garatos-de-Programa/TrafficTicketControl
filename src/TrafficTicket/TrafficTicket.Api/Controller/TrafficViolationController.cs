using Microsoft.AspNetCore.Mvc;
using System.Net;
using TrafficTicket.Api.Models;
using TrafficTicket.Api.Repositories;

namespace TrafficTicket.Api.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TrafficViolationController : ControllerBase
    {
        private readonly ITrafficViolationRepository _trafficViolationRepository;

        public TrafficViolationController(ITrafficViolationRepository trafficViolationRepository)
        {
            _trafficViolationRepository = trafficViolationRepository;
        }

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(TrafficViolation), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(string id)
        {
            var trafficViolation = await _trafficViolationRepository.GetAsycn(id);

            return Ok(trafficViolation ?? new TrafficViolation(id));
        }

        [HttpGet("", Name = "GetTrafficsViolations")]
        [ProducesResponseType(typeof(IEnumerable<TrafficViolation>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTrafficsViolations()
        {
            var trafficViolations = await _trafficViolationRepository.GetTrafficsViolationsAsync();

            return Ok(trafficViolations);
        }

        [HttpPost()]
        [ProducesResponseType(typeof(TrafficViolation), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] TrafficViolation trafficViolation)
        {
            await _trafficViolationRepository.CreateAsync(trafficViolation);

            return CreatedAtAction("Get", new { id = trafficViolation.Id }, trafficViolation);
        }

        [HttpPut]
        [ProducesResponseType(typeof(TrafficViolation), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Update([FromBody] TrafficViolation trafficViolation)
        {
            return Ok(await _trafficViolationRepository.UpdateAsync(trafficViolation));
        }

        [HttpDelete("{id}", Name = "Delete")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string id)
        {
            await _trafficViolationRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
