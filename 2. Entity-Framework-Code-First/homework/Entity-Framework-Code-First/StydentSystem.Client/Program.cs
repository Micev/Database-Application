namespace StudentSystem.Client
{
    using System;
    using StudentSystem.Data;
    using StudentSystem.Data.Migration;
    using StudentSystem.Models;
    using System.Data.Entity;
    public class Program
    {
        public static void Main()
        {
            //Set Database migrate to new changes
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
            var db = new StudentSystemContext();

            //add java course with few resources
            var java = new Course
            {
                Name = "Java",
                Description = "Java Advanced",
                Price = 150,
                StartDate = new DateTime(2013, 10, 27),
                EndDate = new DateTime(2014, 1, 20)
            };

            java.Resources.Add(new Resource
            {
                Name = "Presentation for Java",
                Link = "https://www.softuni.bg",
                Type = ResourceType.Presentation
            });

            java.Resources.Add(new Resource
            {
                Name = "Video for Java",
                Link = "https://www.softuni.bg",
                Type = ResourceType.Video
            });

            //add new student
            var student = new Student
            {
                Name = "Ivan Ivanov",
                PhoneNumber = "+359 899 98 89 98",
                RegistrationDate = new DateTime(2015, 3, 10),
                BirthdayDate = new DateTime(1990, 4, 10)
            };

            //student add new homewrk
            student.Homeworks.Add(new Homework
            {
                Content = "Java Introduction",
                Course = java,
                Type = HomeworkType.Zip,
                EndDate = new DateTime(2015, 2, 10, 23, 59, 59)
            });
            //course add student
            java.Students.Add(student);

            //Database add course with name Java.
            db.Courses.Add(java);
            //Database add new student.
            db.Students.Add(student);
            db.SaveChanges();
            var students = db.Students;

            foreach (var s in students)
            {
                Console.WriteLine("Student " + s.Name);
                Console.Write("HomeWork: ");

                var studentHomeworks = s.Homeworks;

                foreach (var homework in studentHomeworks)
                {
                    Console.WriteLine(homework.Content + ", Content type: " + homework.Type.ToString() + "End date: " + homework.EndDate.ToString());
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
