using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Shared
{
    public class Answer
    {
        [Key]
        public Guid AnswerId { get; set; }
        public Guid StudentExamId { get; set; }
        public Guid QuestionId { get; set; }
        public  string Text { get; set; }
        public int Mark { get; set; }
        public string Comment { get; set; }

        public Answer()
        {
            AnswerId = Guid.NewGuid();
        }
    }
}
