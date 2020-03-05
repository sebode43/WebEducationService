using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEducationService.Data;
using WebEducationService.Models;

namespace WebEducationService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MajorsController : ControllerBase {
        private readonly EdDbContext _context; //readonly - property that does not need to be initialized when you declare it, 
        //but you have to give it a value in your constructor and then it becomes a constant and cannot be changed

        public MajorsController(EdDbContext context) { //context passed in the constructor, do not have to create an instance system does it
            _context = context;
        }

        // GET: api/Majors (getAllMajors) this is the route to get Major
        [HttpGet] //read data/SQL selects data
        public async Task<ActionResult<IEnumerable<Major>>> GetMajor() { //calls GetMajor asynchronously/Action(method)Result calls any type
            return await _context.Majors.ToListAsync(); 
        }

        // GET: api/Majors/5 (getMajorbyPK) this is the rout to get the specific Major
        [HttpGet("{id}")] //more data on the route/put variable in curly braces for route
        public async Task<ActionResult<Major>> GetMajor(int id) { 
            var major = await _context.Majors.FindAsync(id);

            if (major == null) {
                return NotFound(); //returns a piece of JSON data (Error 404:Message Text)
            }

            return major; 
        }

        // PUT: api/Majors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")] //update data
        public async Task<IActionResult> PutMajor(int id, Major major) {
            if (id != major.ID) {
                return BadRequest();
            }

            _context.Entry(major).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!MajorExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Majors //do not have to add anything to the route just POST instead
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost] //add data
        public async Task<ActionResult<Major>> PostMajor(Major major) { //pass Major into this method in the body of the message
            _context.Majors.Add(major);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMajor", new { id = major.ID }, major);
        }

        // DELETE: api/Majors/5
        [HttpDelete("{id}")] //remove data
        public async Task<ActionResult<Major>> DeleteMajor(int id) {
            var major = await _context.Majors.FindAsync(id);
            if (major == null) {
                return NotFound();
            }

            _context.Majors.Remove(major);
            await _context.SaveChangesAsync();

            return major;
        }

        private bool MajorExists(int id) {
            return _context.Majors.Any(e => e.ID == id);
        }
    }
}
