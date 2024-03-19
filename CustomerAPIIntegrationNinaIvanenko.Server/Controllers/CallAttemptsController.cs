using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerAPIIntegration.Models;
using DBTest.Server;

namespace CustomerAPIIntegrationNinaIvanenko.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallAttemptsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CallAttemptsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CallAttempts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CallAttempt>>> GetCallAttempt()
        {
            return await _context.CallAttempt.ToListAsync();
        }

        // GET: api/CallAttempts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CallAttempt>> GetCallAttempt(int id)
        {
            var callAttempt = await _context.CallAttempt.FindAsync(id);

            if (callAttempt == null)
            {
                return NotFound();
            }

            return callAttempt;
        }

        // PUT: api/CallAttempts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCallAttempt(int id, CallAttempt callAttempt)
        {
            if (id != callAttempt.Id)
            {
                return BadRequest();
            }

            _context.Entry(callAttempt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CallAttemptExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CallAttempts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CallAttempt>> PostCallAttempt(CallAttempt callAttempt)
        {
            _context.CallAttempt.Add(callAttempt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCallAttempt", new { id = callAttempt.Id }, callAttempt);
        }

        // DELETE: api/CallAttempts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCallAttempt(int id)
        {
            var callAttempt = await _context.CallAttempt.FindAsync(id);
            if (callAttempt == null)
            {
                return NotFound();
            }

            _context.CallAttempt.Remove(callAttempt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CallAttemptExists(int id)
        {
            return _context.CallAttempt.Any(e => e.Id == id);
        }
    }
}
