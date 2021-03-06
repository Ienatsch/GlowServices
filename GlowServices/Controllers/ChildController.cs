﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlowServices.Data;
using GlowServices.Models.child;
using GlowServices.Repositories.ChildRepository;

namespace GlowServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : IChildRepository
    {
        private readonly GlowServicesContext _context;

        public ChildController(GlowServicesContext context)
        {
            _context = context;
        }

        // GET: api/Child/{userId}
        [HttpGet("{userId}")]
        public IEnumerable<Child> GetChildrenByUser(Guid userId)
        {   
            return _context.Children.Where(x => x.UserId == userId);
        }

        // GET: api/Child/5
        [HttpGet("GetChild/{id}")]
        public Child GetChild(Guid childId)
        {
            var child = _context.Children.FirstOrDefault(x => x.ChildId == childId);
            //var user = _mockData.GetAllUsers().FirstOrDefault(x => x.UserId == id);

            if (child == null)
            {
                return null;
            }

            return child;
        }

        // POST: api/Child
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("AddChild")]
        [HttpPost]
        public async Task<int> AddChild([FromBody] Child child)
        {
            child.ChildId = Guid.NewGuid();
            await _context.AddAsync(child);

            return await _context.SaveChangesAsync();
        }

        // PUT: api/Child/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<int> UpdateChild(Child childUpdates)
        {
            var childToUpdate = _context.Children.FirstOrDefaultAsync(x => x.ChildId == childUpdates.ChildId);

            _context.Update(childToUpdate);

            return await _context.SaveChangesAsync();
        }

        // DELETE: api/Child/5
        [HttpDelete("{childId}")]
        public async Task<int> DeleteChild(Guid childId)
        {
            _context.Children.Remove(await _context.Children.FirstOrDefaultAsync(x => x.ChildId == childId));

            return await _context.SaveChangesAsync();
        }

    }
}
