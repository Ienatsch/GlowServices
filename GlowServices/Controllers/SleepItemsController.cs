using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlowServices.Data;
using GlowServices.Models.Sleep;

namespace GlowServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SleepItemsController : ControllerBase
    {
        private readonly GlowServicesContext _context;

        public SleepItemsController(GlowServicesContext context)
        {
            _context = context;
        }

        // GET: api/SleepItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SleepItem>>> GetSleepItem()
        {
            return await _context.SleepItems.ToListAsync();
        }

        // GET: api/SleepItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SleepItem>> GetSleepItem(Guid? id)
        {
            var sleepItem = await _context.SleepItems.FindAsync(id);

            if (sleepItem == null)
            {
                return NotFound();
            }

            return sleepItem;
        }

        // PUT: api/SleepItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSleepItem(Guid? id, SleepItem sleepItem)
        {
            if (id != sleepItem.SleepId)
            {
                return BadRequest();
            }

            _context.Entry(sleepItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SleepItemExists(id))
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

        // POST: api/SleepItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SleepItem>> PostSleepItem(SleepItem sleepItem)
        {
            _context.SleepItems.Add(sleepItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSleepItem", new { id = sleepItem.SleepId }, sleepItem);
        }

        // DELETE: api/SleepItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SleepItem>> DeleteSleepItem(Guid? id)
        {
            var sleepItem = await _context.SleepItems.FindAsync(id);
            if (sleepItem == null)
            {
                return NotFound();
            }

            _context.SleepItems.Remove(sleepItem);
            await _context.SaveChangesAsync();

            return sleepItem;
        }

        private bool SleepItemExists(Guid? id)
        {
            return _context.SleepItems.Any(e => e.SleepId == id);
        }
    }
}
