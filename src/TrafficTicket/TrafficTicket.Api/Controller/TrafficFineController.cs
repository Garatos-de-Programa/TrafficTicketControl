using Microsoft.AspNetCore.Mvc;
using System.Net;
using TrafficTicket.Api.DataContracts.Queries;
using TrafficTicket.Api.Models.TrafficFine;
using TrafficTicket.Api.Repositories;

namespace TrafficTicket.Api.Controller
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TrafficFineController : ControllerBase
    {
        private readonly ITrafficFineRepository _trafficFineRepository;

        public TrafficFineController(ITrafficFineRepository trafficFineRepository)
        {
            _trafficFineRepository = trafficFineRepository;
        }

        [HttpGet("{id}", Name = "GetTrafficFine")]
        [ProducesResponseType(typeof(TrafficFine), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get(string id)
        {
            var trafficFine = await _trafficFineRepository.GetAsycn(id);

            if (trafficFine is null)
            {
                return NotFound();
            }

            return Ok(trafficFine);
        }

        [HttpGet(Name = "Search")]
        [ProducesResponseType(typeof(TrafficFine), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Search([FromQuery] DateSearchQuery search)
        {
            var trafficFine = await _trafficFineRepository.GetByDateSearch(search);

            if (trafficFine is null)
            {
                return NotFound();
            }

            return Ok(trafficFine);
        }

        [HttpPost()]
        [ProducesResponseType(typeof(TrafficFine), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateProduct([FromBody] TrafficFine trafficFine)
        {
            if (trafficFine == null)
            {
                return BadRequest();
            }

            trafficFine.Id = Guid.NewGuid().ToString();

            await _trafficFineRepository.CreateAsync(trafficFine);

            return CreatedAtAction("Get", new { id = trafficFine.Id }, trafficFine);
        }

        [HttpPut]
        [ProducesResponseType(typeof(TrafficFine), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<TrafficFine>> Update([FromBody] TrafficFine trafficFine)
        {
            return Ok(await _trafficFineRepository.UpdateAsync(trafficFine));
        }

        [HttpDelete("{id}", Name = "DeleteTrafficFine")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            await _trafficFineRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
