﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Shared
{
    public class StudentExam
    {
        [Key]
        public Guid SEId { get; set; }
        public Guid ExamId { get; set; }
        public Guid StudentId { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        public string Comment { get; set; }

        public StudentExam()
        {
            SEId = Guid.NewGuid();
        }
    }
}
