using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Shared
{
    public class Person 
    {
        [Key]
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public Guid AspNetUserId { get; set; }

        public Person()
        {
            PersonId = Guid.NewGuid();
        }
    }
}
