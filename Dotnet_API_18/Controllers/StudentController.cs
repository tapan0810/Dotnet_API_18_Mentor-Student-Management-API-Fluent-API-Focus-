using Dotnet_API_18.Data;
using Dotnet_API_18.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_API_18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(ApplicationDbContext _context) : ControllerBase
    {
        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<List<Student>>> GetAllStudents(int pageNumber, int pageSize)
        {
            var students = await _context.Students
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(s => s.Mentor)
                .ToListAsync();

            if (students is null || students.Count == 0)
                return NotFound("No students found");

            return Ok(students);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _context.Students
                .Include(s => s.Mentor)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (student is null)
                return NotFound($"No student found with id {id}");
            return Ok(student);
        }

        [HttpPost("AddStudent")]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            var mentor = await _context.Mentors.FindAsync(student.MentorId);
            if (mentor is null)
                return BadRequest($"No mentor found with id {student.MentorId}");
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
