using ABTest.API.Data;
using ABTest.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABTest.API.Controllers
{
    [Route("api/experiment")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly TestDbContext _context;

        public TestController(TestDbContext context)
        {
            _context = context;
        }

        [HttpGet("{token}")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByToken(string token)
        {
            var client = await _context.Clients.FindAsync(token);

            if(client == null)
            {
                return NotFound("The client by this token does not exist");
            }

            return Ok(client);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] Client client)
        {

            if(await _context.Clients.AnyAsync(c => c.Token == client.Token))
            {
                return BadRequest("The recieved data isn't valid, the client has already created");
            }
            else if(client == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }

            client.Experiment.Name = client.Token.ToString() + $"Exp{client.Experiment.Id}";

            await _context.Clients.AddAsync(client);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByToken), client);
        }
    }
}
