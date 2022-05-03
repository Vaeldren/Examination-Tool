using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Shared
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
