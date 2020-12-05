namespace Alkemy_C.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ci = c.Int(nullable: false),
                        name = c.String(),
                        last_name = c.String(),
                        active = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        places = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        day = c.String(),
                        hr_start = c.DateTime(nullable: false),
                        hr_end = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectAlumns",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        Alumn_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Alumn_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Alumn_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.Alumn_Id);
            
            CreateTable(
                "dbo.ScheduleSubjects",
                c => new
                    {
                        Schedule_Id = c.Int(nullable: false),
                        Subject_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Schedule_Id, t.Subject_Id })
                .ForeignKey("dbo.Schedules", t => t.Schedule_Id, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .Index(t => t.Schedule_Id)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.TeacherSubjects",
                c => new
                    {
                        Teacher_Id = c.Int(nullable: false),
                        Subject_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_Id, t.Subject_Id })
                .ForeignKey("dbo.People", t => t.Teacher_Id, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .Index(t => t.Teacher_Id)
                .Index(t => t.Subject_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherSubjects", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.TeacherSubjects", "Teacher_Id", "dbo.People");
            DropForeignKey("dbo.ScheduleSubjects", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.ScheduleSubjects", "Schedule_Id", "dbo.Schedules");
            DropForeignKey("dbo.SubjectAlumns", "Alumn_Id", "dbo.People");
            DropForeignKey("dbo.SubjectAlumns", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.TeacherSubjects", new[] { "Subject_Id" });
            DropIndex("dbo.TeacherSubjects", new[] { "Teacher_Id" });
            DropIndex("dbo.ScheduleSubjects", new[] { "Subject_Id" });
            DropIndex("dbo.ScheduleSubjects", new[] { "Schedule_Id" });
            DropIndex("dbo.SubjectAlumns", new[] { "Alumn_Id" });
            DropIndex("dbo.SubjectAlumns", new[] { "Subject_Id" });
            DropTable("dbo.TeacherSubjects");
            DropTable("dbo.ScheduleSubjects");
            DropTable("dbo.SubjectAlumns");
            DropTable("dbo.Schedules");
            DropTable("dbo.Subjects");
            DropTable("dbo.People");
        }
    }
}
