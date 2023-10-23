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
        public async Task<ActionResult<Experiment>> GetByToken(string token)
        {
            var ex = await _context.Experiments.FindAsync(token);

            if (ex == null)
            {
                return NotFound("The experiment by this token does not exist");
            }

            return ex;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] Client client)
        {
            if (client == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            //var check = await _context.Clients.AnyAsync(c => c.Token == client.Token);
            else if (await _context.Clients.AnyAsync(c => c.ClientId == client.ClientId))
            {
                return BadRequest("The recieved data isn't valid, the client has already created");
            }

            client.Experiment.Name = client.Experiment.Token.ToString() + "Exp";

            await _context.Experiments.AddAsync(client.Experiment);

            await _context.Clients.AddAsync(client);           

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create),new { name = client.Experiment.Name }, client);
        }
    }
}
