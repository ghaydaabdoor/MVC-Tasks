using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstTask2.Models
{
    public class StudentDetails
    {
        [Key]
        public int StudentDetailsId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }

}