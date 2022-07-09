using FinalYearProject.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalYearProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    { 
    
        public ValuesController(UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<IdentityUser> UserManager { get; private set; }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<Guid>> Get()
        {
            IdentityUser applicationUser = await UserManager.GetUserAsync(User);
            return Guid.Parse(applicationUser?.Id);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
