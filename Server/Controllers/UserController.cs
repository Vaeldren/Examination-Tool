using FinalYearProject.Server.Models;
using FinalYearProject.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalYearProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetPerson()
        {
            List<ApplicationUser> users = _userManager.Users.ToList();
            List<Person> people = new List<Person>();

            foreach (var p in users)
            {
                Person nPerson = new Person();
                nPerson.AspNetUserId = Guid.Parse(p.Id);
                nPerson.FirstName = p.UserName;
                people.Add(nPerson);
            }
            return people;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(Guid id)
        {
            var person = await _userManager.FindByIdAsync(id.ToString());

            if (person == null)
            {
                return NotFound();
            }

            var nPerson = new Person();

            nPerson.FirstName = person.UserName;
            nPerson.AspNetUserId = Guid.Parse(person.Id);

            return nPerson;
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
