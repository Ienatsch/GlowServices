using GlowServices.Models.child;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlowServices.Repositories.ChildRepository
{
    public interface IChildRepository
    {
        Child GetChild(Guid id);
        IEnumerable<Child> GetAllChildren();
        Task<int> AddChild(Child newChild);
        Task<int> UpdateChild(Child childUpdates);
        Task<int> DeleteChild(Guid id);
    }
}
