using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Shared
{
    public class Exam
    {
        [Key]
        public Guid ExamId { get; set; }
        public Guid TeacherId { get; set; }
        public int ExamCode { get; set; }
        public string ExamName { get; set; }
        public List<Question> ExamQuestions { get; set; }
        public int Total;

    }
}
