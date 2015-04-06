
namespace StudentSystem.Data.Migration
{
    using System.Data.Entity.Migrations;
    using StudentSystem.Models;
    using StudentSystem.Data;
    using System;
    using System.Linq;
    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "StudentSystem.Date.StudentsystemContext";
        }

        protected override void Seed(StudentSystemContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            //Add few Students

            var pesho = new Student
            {
                Name = "Pesho",
                PhoneNumber = "0888 08 08 08",
                BirthdayDate = new DateTime(1987, 6, 12),
                RegistrationDate = new DateTime(2015, 3, 10)
            };

            var gosho = new Student
            {
                Name = "Gosho",
                PhoneNumber = "+359 888 88 88 88",
                BirthdayDate = new DateTime(1990, 4, 10),
                RegistrationDate = new DateTime(2015, 3, 10)
            };

            var minka = new Student
            {
                Name = "Minka",
                PhoneNumber = "+359 898 12 34 56",
                BirthdayDate = new DateTime(1993, 11, 26),
                RegistrationDate = new DateTime(2015, 3, 10)
            };
            context.Students.AddOrUpdate(pesho);
            context.Students.AddOrUpdate(gosho);
            context.Students.AddOrUpdate(minka);

            //Add few Resources
            var resource1 = new Resource
            {
                Name = "Video",
                Type = ResourceType.Video,
                Link = "www.youtube.com"
            };

            var resource2 = new Resource
            {
                Name = "Document",
                Type = ResourceType.Document,
                Link = "www.SoftUni.bg"
            };
            context.Resources.AddOrUpdate(resource1);
            context.Resources.AddOrUpdate(resource2);

            //add few Courses
            var cSharpBasic = new Course
            {
                Name = "ASP.NET Basic",
                Description = "Be progresive developer",
                StartDate = new DateTime(2014, 1, 1),
                EndDate = new DateTime(2014, 1, 30),
                Price = 250
            };

            var javaScript = new Course
            {
                Name = "JavaScript basic",
                Description = "Be succesfull front-end developer",
                StartDate = new DateTime(2014, 6, 23),
                EndDate = new DateTime(2015, 9, 25),
                Price = 150
            };

            context.Courses.AddOrUpdate(javaScript);
            context.Courses.AddOrUpdate(cSharpBasic);
            javaScript.Resources.Add(resource2);
            cSharpBasic.Resources.Add(resource1);

            //save all data
            context.SaveChanges();

            //add homework
            var student = context.Students.Find(1);
            var course = context.Courses.Find(1);

            var homework = new Homework
            {
                Content = "Homework",
                Course = course,
                Student = student,
                EndDate = new DateTime(2015, 2, 10, 23, 59, 59),
            };

            context.Homeworks.AddOrUpdate(homework);
            context.SaveChanges();
        }
    }
}
