using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstTask2.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }

}