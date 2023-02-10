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
    public class ExamsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ExamsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Exams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExams()
        {

            return await _context.Exams.ToListAsync();

        }

        // GET: api/Exams/user

        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<Exam>>> GetUserExams()
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            var E = await _context.Exams.ToListAsync();
            List<Exam> NE = new List<Exam>();
            foreach (var i in E)
            {
                if (i.TeacherId == Guid.Parse(applicationUser?.Id))
                {
                    NE.Add(i);
                }
            }
            return NE;
        }

        // GET: api/Exams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExam(Guid id)
        {
            var exam = await _context.Exams.FindAsync(id);

            if (exam == null)
            {
                return NotFound();
            }

            return exam;
        }

        // PUT: api/Exams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExam(Guid id, Exam exam)
        {
            if (id != exam.ExamId)
            {
                return BadRequest();
            }
            var sExam = _context.StudentExams.ToList();
            foreach (var sE in sExam)
            {
                if(sE.ExamId == exam.ExamId)
                {
                    return NoContent();
                }
            }
            _context.Entry(exam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(id))
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

        // POST: api/Exams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exam>> PostExam(Exam exam)
        {
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            exam.TeacherId = Guid.Parse(applicationUser?.Id);
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExam", new { id = exam.ExamId }, exam);
        }

        // DELETE: api/Exams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(Guid id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }


            var sExam =  _context.StudentExams.ToList();
            foreach (var i in sExam)
            {
                if(i.ExamId == exam.ExamId)
                {
                    _context.StudentExams.Remove(i);
                }
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamExists(Guid id)
        {
            return _context.Exams.Any(e => e.ExamId == id);
        }
    }
}
