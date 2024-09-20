namespace CodeFirstTask2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentDetails", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentDetails", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
