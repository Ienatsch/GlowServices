using GlowServices.Models;
using GlowServices.Models.child;
using GlowServices.Repositories.ChildRepository;
using GlowServices.Repositories.FeedingRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlowServices.Repositories.UserRepository
{
    public class MockFeedingRepository : IFeedingRepository
    {
        private List<FeedingItem> _feedingList;

        public MockFeedingRepository()
        {
            _feedingList = new List<FeedingItem>()
            {
                //new FeedingItem() {FeedingId = new Guid("24d31e19-a250-47c8-9402-81feeabf4013"), ChildId = new Guid("9825eaf7-1742-4112-9715-5563fdfd4322"), FeedingDate = new DateTime(3, 24, 2020), Time = new DateTime().TimeOfDay, Oz = 4, TimeSinceLastFeed = new TimeSpan()},
                //new FeedingItem() {FeedingId = new Guid("92baf41c-f195-4560-8d5b-6ce8ca6930cf"), ChildId = new Guid("9825eaf7-1742-4112-9715-5563fdfd4322"), Date = new DateTime(3, 24, 2020), Time = new DateTime().TimeOfDay, Oz = 8, TimeSinceLastFeed = new TimeSpan()},
                //new FeedingItem() {FeedingId = new Guid("5c85937d-6679-413a-895e-062e696e7afe"), ChildId = new Guid("898731f4-8d60-467b-9784-f1f47f2d8c16"), Date = new DateTime(1, 19, 2020), Time = new DateTime().TimeOfDay, Oz = 5, TimeSinceLastFeed = new TimeSpan()}
            };

        }

        public IEnumerable<FeedingItem> GetAllFeedingItems(Guid childId)
        {
            throw new NotImplementedException();
            //return _feedingList;
        }

        public FeedingItem GetFeedingItem(Guid id)
        {
            throw new NotImplementedException();
            //return _feedingList.FirstOrDefault(x => x.FeedingId == id);
        }


        public Task<int> AddFeedingItem(FeedingItem newFeedingItem)
        {

            throw new NotImplementedException();
        }

        public Task<int> UpdateFeedingItem(FeedingItem feedingItemUpdates)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteFeedingItem(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
