using GlowServices.Models.Sleep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlowServices.Repositories.SleepRepository
{
    public interface ISleepRepository
    {
        IEnumerable<SleepItem> GetAllSleepItems(Guid childId);
        SleepItem GetSleepItem(Guid SleepId);
        Task<int> AddSleepItem(SleepItem SleepItem);
        Task<int> UpdateSleepItem(SleepItem SleepItemUpdates);
        Task<int> DeleteSleepItem(Guid SleepId);
    }
}
