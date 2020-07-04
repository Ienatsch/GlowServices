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
    public class UserController : ControllerBase, IUserRepository
    {
        private readonly GlowServicesContext _context;
        private IEncryptionService _encryptionService;

        public UserController(GlowServicesContext context, IEncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public User GetUser(Guid userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == userId);
            //var user = _mockData.GetAllUsers().FirstOrDefault(x => x.UserId == id);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        // Post: api/User
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("Register")]
        [HttpPost]
        public async Task<int> AddUser([FromBody] User newUser)
        {
            newUser.UserId = Guid.NewGuid();
            newUser.UserPassword = _encryptionService.Encrypt(newUser.UserPassword);
            await _context.Users.AddAsync(newUser);

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
        public async Task<int> DeleteUser(Guid userId)
        {
            _context.Users.Remove(await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId));
            return await _context.SaveChangesAsync();
        }

        [Route("LoginUser")]
        [HttpPost]    
        public async Task<IActionResult> LoginUser([FromQuery] string username, [FromQuery] string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserUsername == username);
            if (user != null && _encryptionService.Decrypt(user.UserPassword) == password)
            {
                return Ok(user); 
            }
            return StatusCode(401);
        }
    }
}
