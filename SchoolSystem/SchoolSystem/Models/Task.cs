using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolSystem.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; } 
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string DueDate { get; set; }
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
    }

}