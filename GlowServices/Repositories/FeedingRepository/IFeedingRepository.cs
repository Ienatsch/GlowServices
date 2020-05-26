using GlowServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlowServices.Repositories.FeedingRepository
{
    public interface IFeedingRepository
    {
        Task<IEnumerable<FeedingItem>> GetAllFeedingItems(Guid childId);
        Task<FeedingItem> GetFeedingItem(Guid feedingId);
        Task<int> AddFeedingItem(FeedingItem feedingItem);
        Task<int> UpdateFeedingItem(FeedingItem feedingItemUpdates);
        Task<int> DeleteFeedingItem(Guid feedingId);
    }
}
