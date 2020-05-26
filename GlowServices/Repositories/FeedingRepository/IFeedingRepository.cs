using GlowServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlowServices.Repositories.FeedingRepository
{
    public interface IFeedingRepository
    {
        IEnumerable<FeedingItem> GetAllFeedingItems();
        FeedingItem GetFeedingItem(Guid id);
        Task<int> AddFeedingItem(FeedingItem newFeedingItem);
        Task<int> UpdateFeedingItem(FeedingItem feedingItemUpdates);
        Task<int> DeleteFeedingItem(Guid id);
    }
}
