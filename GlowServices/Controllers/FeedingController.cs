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
    public class FeedingsController : IFeedingRepository
    {
        private readonly GlowServicesContext _context;

        public FeedingsController(GlowServicesContext context)
        {
            _context = context;
        }

        // GET: api/Feeding
        [HttpGet]
        public async Task<IEnumerable<FeedingItem>> GetAllFeedingItems(Guid childId)
        {
            return await _context.FeedingItems.Where(x => x.ChildId == childId).ToListAsync();
        }

        // GET: api/Feeding/5
        [HttpGet("{id}")]
        public async Task<FeedingItem> GetFeedingItem(Guid feedingId)
        {
            return await _context.FeedingItems.FirstOrDefaultAsync(x => x.FeedingId == feedingId);
        }  

        // POST: api/Feeding
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<int> AddFeedingItem(FeedingItem feedingItem)
        {
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
        [HttpDelete("{id}")]
        public async Task<int> DeleteFeedingItem(Guid feedingId)
        {
            _context.FeedingItems.Remove(await _context.FeedingItems.FirstOrDefaultAsync(x => x.FeedingId == feedingId));

            return await _context.SaveChangesAsync();
        }

    }
}
