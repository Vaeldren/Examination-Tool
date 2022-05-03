using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_Prototype.Shared
{
    public class Question
    {
        [Key]
        public  Guid QuestionId { get; set; }
        public Guid ExamId { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
    }
}
