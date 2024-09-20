namespace CodeFirstTask2.Migrations
{
    using CodeFirstTask2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstTask2.Models.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFirstTask2.Models.SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // Adding a new teacher if it doesn't exist
            context.Teachers.AddOrUpdate(t => t.Name, // AddOrUpdate checks for existing data
                new Teacher { Name = "John Doe", Subject = "Mathematics" },
                new Teacher { Name = "Jane Smith", Subject = "Science" }
            );

            // Ensure you save changes
            context.SaveChanges();

        }
    }
}
