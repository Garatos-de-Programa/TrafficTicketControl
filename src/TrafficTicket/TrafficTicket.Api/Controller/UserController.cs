using Microsoft.AspNetCore.Mvc;
using System.Net;
using TrafficTicket.Api.Models;
using TrafficTicket.Api.Repositories;

namespace TrafficTicket.Api.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userRepository.GetAsycn(id);

            return Ok(user ?? new User(id));
        }

        [HttpGet("", Name = "GetUsers")]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();

            return Ok(users);
        }

        [HttpPost()]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            await _userRepository.CreateAsync(user);

            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        [HttpPut]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Update([FromBody] User user)
        {
            return Ok(await _userRepository.UpdateAsync(user));
        }

        [HttpDelete("{id}", Name = "Delete")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string id)
        {
            await _userRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
