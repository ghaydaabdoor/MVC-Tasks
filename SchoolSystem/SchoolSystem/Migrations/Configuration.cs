namespace SchoolSystem.Migrations
{
    using SchoolSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Reflection.Emit;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolSystem.Models.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolSystem.Models.SchoolContext context)
        {
            context.Courses.AddOrUpdate(t => t.CourseName,
                 new Course { CourseId = 1, CourseName = "Math", CourseDescription = "This course covers fundamental mathematical concepts like algebra, geometry, and calculus, focusing on problem-solving and critical thinking skills.\r\n\r\n" },
                 new Course { CourseId = 2, CourseName = "Science", CourseDescription = "Explore core principles of physics, chemistry, and biology through hands-on experiments and practical applications in this foundational science course.\r\n\r\n" },
                 new Course { CourseId = 3, CourseName = "Arabic", CourseDescription = "Develop language proficiency in reading, writing, and speaking Arabic while exploring cultural and literary aspects of the language.\r\n\r\n\r\n\r\n\r\n\r\n\r\n" }
             );

            context.Users.AddOrUpdate(t => t.Email,
                new User { UserId = 1, Email = "ghayda@yahoo.com", Password = "123" },
                new User { UserId = 2, Email = "Ali@gmail.com", Password = "123" },
                new User { UserId = 3, Email = "Ahmad@gmail.com", Password = "123" }
             );

            context.Students.AddOrUpdate(t => t.StudentName,
            new Student { StudentId = 1, StudentName = "Alice Johnson", Age = 12, Gender = "Female", Email = "alice.johnson@example.com", ClassId = 1 },
            new Student { StudentId = 2, StudentName = "Bob Smith", Age = 13, Gender = "Male", Email = "bob.smith@example.com", ClassId = 1 },
            new Student { StudentId = 3, StudentName = "Charlie Brown", Age = 11, Gender = "Male", Email = "charlie.brown@example.com", ClassId = 2 },
            new Student { StudentId = 4, StudentName = "Diana Prince", Age = 12, Gender = "Female", Email = "diana.prince@example.com", ClassId = 2 },
            new Student { StudentId = 5, StudentName = "Edward Elric", Age = 13, Gender = "Male", Email = "edward.elric@example.com", ClassId = 3 },
            new Student { StudentId = 6, StudentName = "Fiona Green", Age = 12, Gender = "Female", Email = "fiona.green@example.com", ClassId = 3 }
             );

           context.Tasks.AddOrUpdate(t => t.TaskName,
            new Task { TaskId = 1, TaskName = "Math Homework", TaskDescription = "Complete Algebra exercises", DueDate = "2024-09-30", ClassId = 1 },
            new Task { TaskId = 2, TaskName = "Science Project", TaskDescription = "Build a volcano model", DueDate = "2024-10-05", ClassId = 1 },
            new Task { TaskId = 3, TaskName = "History Essay", TaskDescription = "Write about World War II", DueDate = "2024-09-28", ClassId = 2 },
            new Task { TaskId = 4, TaskName = "Art Assignment", TaskDescription = "Draw a portrait", DueDate = "2024-10-10", ClassId = 2 },
            new Task { TaskId = 5, TaskName = "English Reading", TaskDescription = "Read chapter 4 of the novel", DueDate = "2024-09-27", ClassId = 3 },
            new Task { TaskId = 6, TaskName = "Physical Education", TaskDescription = "Prepare for the school race", DueDate = "2024-10-02", ClassId = 3 }
            );
        }

            
    }
}
