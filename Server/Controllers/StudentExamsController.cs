using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalYearProject.Server.Data;
using FinalYearProject.Shared;
using Microsoft.AspNetCore.Identity;
using FinalYearProject.Server.Models;

namespace FinalYearProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public StudentExamsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/StudentExams/user
        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<StudentExam>>> GetUserStudentExams()
        {
            IdentityUser applicationUser = await _userManager.GetUserAsync(User);
            var SE = await _context.StudentExams.ToListAsync();
            var SEE = new List<StudentExam>();
            foreach(var i in SE)
            {
                
                if (i.StudentId == Guid.Parse(applicationUser?.Id))
                {
                    SEE.Add(i);
                }
            }
            return SEE;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentExam>>> GetStudentExams()
        {
            return await _context.StudentExams.ToListAsync();
        }

        // GET: api/StudentExams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentExam>> GetStudentExam(Guid id)
        {
            var studentExam = await _context.StudentExams.FindAsync(id);

            if (studentExam == null)
            {
                return NotFound();
            }

            return studentExam;
        }

        // PUT: api/StudentExams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentExam(Guid id, StudentExam studentExam)
        {
            if (id != studentExam.SEId)
            {
                return BadRequest();
            }
            _context.Entry(studentExam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExamExists(id))
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

        // POST: api/StudentExams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentExam>> PostStudentExam(StudentExam studentExam)
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            studentExam.StudentId = Guid.Parse(applicationUser?.Id);
            _context.StudentExams.Add(studentExam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentExam", new { id = studentExam.SEId }, studentExam);
        }

        // DELETE: api/StudentExams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentExam(Guid id)
        {
            var studentExam = await _context.StudentExams.FindAsync(id);
            if (studentExam == null)
            {
                return NotFound();
            }

            _context.StudentExams.Remove(studentExam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExamExists(Guid id)
        {
            return _context.StudentExams.Any(e => e.SEId == id);
        }
    }
}
