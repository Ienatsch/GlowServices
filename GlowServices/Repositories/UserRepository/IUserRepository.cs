using GlowServices.Models.user;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlowServices.Repositories.UserRepository
{
    public interface IUserRepository
    {
        User GetUser(Guid userId);
        IEnumerable<User> GetAllUsers();
        Task<int> AddUser(User newUser);
        Task<int> UpdateUser(User userUpdates);
        Task<int> DeleteUser(Guid userId);
        Task<IActionResult> LoginUser([FromQuery] string username, [FromQuery] string password);
    }
}
