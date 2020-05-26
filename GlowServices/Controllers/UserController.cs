using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlowServices.Data;
using GlowServices.Models.user;
using GlowServices.Repositories.UserRepository;

namespace GlowServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : IUserRepository
    {
        private readonly GlowServicesContext _context;
        private MockUserRepository _mockData;
        private IEncryptionService _encryptionService;

        public UserController(GlowServicesContext context, IEncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
            _mockData = new MockUserRepository(_encryptionService);
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public User GetUser(Guid id)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == id);
            //var user = _mockData.GetAllUsers().FirstOrDefault(x => x.UserId == id);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        // PUT: api/User
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<int> AddUser(User newUser)
        {
            newUser.UserPassword = _encryptionService.Encrypt(newUser.UserPassword);
            await _context.AddAsync(newUser);

            return await _context.SaveChangesAsync();
        }

        // PUT: api/User/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<int> UpdateUser(User userUpdates)
        {
            var userToUpdate = _context.Users.FirstOrDefaultAsync(x => x.UserId == userUpdates.UserId);
            
            _context.Update(userToUpdate);

            return await _context.SaveChangesAsync();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<int> DeleteUser(Guid id)
        {
            _context.Users.Remove(await _context.Users.FirstOrDefaultAsync(x => x.UserId == id));
            return await _context.SaveChangesAsync();
        }

    }
}
