using GlowServices.Data;
using GlowServices.Models.user;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlowServices.Repositories.UserRepository
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> _userList;
        private IEncryptionService _encryptionService;
        public MockUserRepository(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;

            _userList = new List<User>()
            {
                new User() {UserId = new Guid("20fce906-f1b9-4b33-a70a-36baefaf78ba"), UserUsername = "KMontes97", UserPassword = "jRk1909", UserFirstName = "Kate", UserLastName = "Montesdeoca", UserEmail = "kmontes97@gmail.com"},
                new User() {UserId = new Guid("878ac96a-516d-47b8-8228-285c1cc71559"), UserUsername = "carnoux", UserPassword = "myPass2020", UserFirstName = "Dalan", UserLastName = "Ienatsch", UserEmail = "dienatsch93@gmail.com"},
                new User() {UserId = new Guid("38238dd7-f0aa-49ed-b463-0ea064d9beae"), UserUsername = "jujo", UserPassword = "98!Enk@", UserFirstName = "John", UserLastName = "Jones", UserEmail = "jujo_beast@gmail.com"},
            };

            _userList.ForEach(x => x.UserPassword = _encryptionService.Encrypt(x.UserPassword));
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userList;
        }

        public User GetUser(Guid id)
        {
            return _userList.FirstOrDefault(x => x.UserId == id);
        }


        public Task<int> AddUser(User newUser)
        {
            var _userPassword = System.Security.Cryptography.Aes.Create(newUser.UserPassword);

            throw new NotImplementedException();
        }

        public Task<int> UpdateUser(User userUpdates)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> LoginUser([FromQuery] string username, [FromQuery] string password)
        {
            throw new NotImplementedException();
        }

    }
}
