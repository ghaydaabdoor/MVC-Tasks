using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstTask2.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentDetails> StudentDetails { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOptional(s => s.StudentDetails) 
                .WithRequired(sd => sd.Student); 

            modelBuilder.Entity<Teacher>()
           .HasMany(t => t.Courses)  
           .WithRequired(c => c.Teacher)  
           .HasForeignKey(c => c.TeacherId);
        }
    }
}