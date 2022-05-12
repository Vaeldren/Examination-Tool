using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalYearProject.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; internal set; }
        public string SecondName { get; internal set; }
    }
}
