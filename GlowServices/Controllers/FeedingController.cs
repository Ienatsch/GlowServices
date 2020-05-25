using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlowServices.Data;
using GlowServices.Models;

namespace GlowServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedingsController : ControllerBase
    {
        private readonly GlowServicesContext _context;

        public FeedingsController(GlowServicesContext context)
        {
            _context = context;
        }

        // GET: api/Feeding
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedingItem>>> GetFeedingItem()
        {
            return await _context.FeedingItems.ToListAsync();
        }

        // GET: api/Feeding/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedingItem>> GetFeedingItem(Guid id)
        {
            var FeedingItem = await _context.FeedingItems.FindAsync(id);

            if (FeedingItem == null)
            {
                return NotFound();
            }

            return FeedingItem;
        }

        // PUT: api/Feeding/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedingItem(Guid id, FeedingItem FeedingItem)
        {
            if (id != FeedingItem.FeedingId)
            {
                return BadRequest();
            }

            _context.Entry(FeedingItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedingItemExists(id))
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

        // POST: api/Feeding
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FeedingItem>> PostFeedingItem(FeedingItem FeedingItem)
        {
            _context.FeedingItems.Add(FeedingItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedingItem", new { id = FeedingItem.FeedingId }, FeedingItem);
        }

        // DELETE: api/Feeding/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FeedingItem>> DeleteFeedingItem(Guid id)
        {
            var FeedingItem = await _context.FeedingItems.FindAsync(id);
            if (FeedingItem == null)
            {
                return NotFound();
            }

            _context.FeedingItems.Remove(FeedingItem);
            await _context.SaveChangesAsync();

            return FeedingItem;
        }

        private bool FeedingItemExists(Guid id)
        {
            return _context.FeedingItems.Any(e => e.FeedingId == id);
        }
    }
}
