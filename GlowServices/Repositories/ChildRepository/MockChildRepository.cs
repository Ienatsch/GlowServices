using GlowServices.Models.child;
using GlowServices.Repositories.ChildRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlowServices.Repositories.UserRepository
{
    public class MockChildRepository : IChildRepository
    {
        private List<Child> _childList;

        public MockChildRepository()
        {
            _childList = new List<Child>()
            {
                new Child() {UserId = new Guid("20fce906-f1b9-4b33-a70a-36baefaf78ba"), ChildId = new Guid("9825eaf7-1742-4112-9715-5563fdfd4322"), ChildFirstName = "Jayden", ChildBirthDate = new DateTime(2019, 03, 17), ChildHeight = 32, ChildHeightType = "in", ChildWeight = 21, ChildWeightType = "lbs"},
                new Child() {UserId = new Guid("8bc2e01e-0672-4155-8992-7539f608ddf3"), ChildId = new Guid("abba6e60-1dc5-4f31-98f7-262afd3d9d12"), ChildFirstName = "Iris", ChildBirthDate = new DateTime(2020, 11, 03), ChildHeight = 22, ChildHeightType = "in", ChildWeight = 13, ChildWeightType = "lbs"},
                new Child() {UserId = new Guid("750a2786-be32-445b-8987-a9305167c9b8"), ChildId = new Guid("898731f4-8d60-467b-9784-f1f47f2d8c16"), ChildFirstName = "Jack", ChildBirthDate = new DateTime(2017, 01, 31), ChildHeight = 40, ChildHeightType = "in", ChildWeight = 25, ChildWeightType = "lbs"},
            };

        }

        public IEnumerable<Child> GetChildrenByUser(Guid userId)
        {
            return _childList;
        }

        public Child GetChild(Guid id)
        {
            return _childList.FirstOrDefault(x => x.ChildId == id);
        }


        public Task<int> AddChild(Child newChild)
        {

            throw new NotImplementedException();
        }

        public Task<int> UpdateChild(Child childUpdates)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteChild(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
