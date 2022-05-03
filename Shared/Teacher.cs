using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_Prototype.Shared
{
    public class Teacher
    {
        [Key]
        public Guid TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
