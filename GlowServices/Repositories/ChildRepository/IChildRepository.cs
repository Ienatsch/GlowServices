using GlowServices.Models.child;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlowServices.Repositories.ChildRepository
{
    public interface IChildRepository
    {
        Child GetChild(Guid childId);
        IEnumerable<Child> GetChildrenByUser(Guid userId);
        Task<int> AddChild(Child newChild);
        Task<int> UpdateChild(Child childUpdates);
        Task<int> DeleteChild(Guid childId);
    }
}
