using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlowServices.Data;
using GlowServices.Models;
using GlowServices.Repositories.FeedingRepository;

namespace GlowServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedingController : IFeedingRepository
    {
        private readonly GlowServicesContext _context;

        public FeedingController(GlowServicesContext context)
        {
            _context = context;
        }

        // GET: api/Feeding
        [HttpGet("{childId}")]
        public IEnumerable<FeedingItem> GetAllFeedingItems(Guid childId)
        {
            var feedings = _context.Feedings.Where(x => x.ChildId == childId).ToList();
            return feedings;
        }


        // GET: api/Feeding/5
        [HttpGet("GetFeeding/{feedingId}")]
        public FeedingItem GetFeedingItem(Guid feedingId)
        {
            return _context.Feedings.FirstOrDefault(x => x.FeedingId == feedingId);
        }

        // POST: api/Feeding
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<int> AddFeedingItem(FeedingItem feedingItem)
        {
            feedingItem.FeedingId = Guid.NewGuid();
            feedingItem.FeedingDate = DateTime.Today;
            feedingItem.TimeSinceLastFeed = TimeSpan.FromSeconds(200);
            await _context.AddAsync(feedingItem);

            return await _context.SaveChangesAsync();
        }

        // PUT: api/Feeding/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<int> UpdateFeedingItem(FeedingItem feedingItemUpdates)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Feeding/5
        [HttpDelete("{feedingId}")]
        public async Task<int> DeleteFeedingItem(Guid feedingId)
        {
            _context.Feedings.Remove(await _context.Feedings.FirstOrDefaultAsync(x => x.FeedingId == feedingId));

            return await _context.SaveChangesAsync();
        }

    }
}
