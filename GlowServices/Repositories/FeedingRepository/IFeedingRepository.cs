using GlowServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlowServices.Repositories.FeedingRepository
{
    public interface IFeedingRepository
    {
        FeedingItem GetFeedings(string id);
        FeedingItem AddFeeding(string id);
        FeedingItem EditFeeding(string id);
        FeedingItem DeleteFeeding(string id);
    }
}
