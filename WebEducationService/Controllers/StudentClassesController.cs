using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEducationService.Data;
using WebEducationService.Models;

namespace WebEducationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentClassesController : ControllerBase
    {
        private readonly EdDbContext _context;

        public StudentClassesController(EdDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentClass>>> GetStudentClass()
        {
            return await _context.StudentClass.ToListAsync();
        }

        // GET: api/StudentClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentClass>> GetStudentClass(int id)
        {
            var studentClass = await _context.StudentClass.FindAsync(id);

            if (studentClass == null)
            {
                return NotFound();
            }

            return studentClass;
        }

        // PUT: api/StudentClasses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentClass(int id, StudentClass studentClass)
        {
            if (id != studentClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentClasses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StudentClass>> PostStudentClass(StudentClass studentClass)
        {
            _context.StudentClass.Add(studentClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentClass", new { id = studentClass.Id }, studentClass);
        }

        // DELETE: api/StudentClasses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentClass>> DeleteStudentClass(int id)
        {
            var studentClass = await _context.StudentClass.FindAsync(id);
            if (studentClass == null)
            {
                return NotFound();
            }

            _context.StudentClass.Remove(studentClass);
            await _context.SaveChangesAsync();

            return studentClass;
        }

        private bool StudentClassExists(int id)
        {
            return _context.StudentClass.Any(e => e.Id == id);
        }
    }
}
