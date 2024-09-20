using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace SchoolSystem.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("DefaultConnectionGH")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }

}