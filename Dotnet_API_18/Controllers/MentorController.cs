using Dotnet_API_18.Data;
using Dotnet_API_18.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dotnet_API_18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MentorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/mentor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mentor>>> GetAllMentors()
        {
            return await _context.Mentors.ToListAsync();
        }

        // GET: api/mentor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mentor>> GetMentorById(int id)
        {
            var mentor = await _context.Mentors
                .Include(m => m.Students)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mentor == null)
                return NotFound("Mentor not found");

            return mentor;
        }

        // POST: api/mentor
        [HttpPost]
        public async Task<ActionResult<Mentor>> CreateMentor(Mentor mentor)
        {
            _context.Mentors.Add(mentor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMentorById), new { id = mentor.Id }, mentor);
        }

        // PUT: api/mentor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMentor(int id, Mentor mentor)
        {
            if (id != mentor.Id)
                return BadRequest();

            _context.Entry(mentor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/mentor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMentor(int id)
        {
            var mentor = await _context.Mentors.FindAsync(id);

            if (mentor == null)
                return NotFound();

            _context.Mentors.Remove(mentor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
    }
