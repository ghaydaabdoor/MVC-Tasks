using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }


        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }

}