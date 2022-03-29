using Microsoft.AspNetCore.Mvc;
using System.Net;
using TrafficTicket.Api.Models.TrafficFine;
using TrafficTicket.Api.Repositories;

namespace TrafficTicket.Api.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TrafficFineController : ControllerBase
    {
        private readonly ITrafficFineRepository _trafficFineRepository;

        public TrafficFineController(ITrafficFineRepository trafficFineRepository)
        {
            _trafficFineRepository = trafficFineRepository;
        }

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(TrafficFine), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(string id)
        {
            var trafficFine = await _trafficFineRepository.GetAsycn(id);

            return Ok(trafficFine ?? new TrafficFine(id));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(TrafficFine), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateProduct([FromBody] TrafficFine trafficFine)
        {
            await _trafficFineRepository.CreateAsync(trafficFine);

            return CreatedAtAction("Get", new { id = trafficFine.Id }, trafficFine);
        }

        [HttpPut]
        [ProducesResponseType(typeof(TrafficFine), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TrafficFine>> Update([FromBody] TrafficFine trafficFine)
        {
            return Ok(await _trafficFineRepository.UpdateAsync(trafficFine));
        }

        [HttpDelete("{id}", Name = "Delete")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string id)
        {
            await _trafficFineRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
