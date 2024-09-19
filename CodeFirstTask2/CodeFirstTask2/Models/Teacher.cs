using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstTask2.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }

}