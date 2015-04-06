namespace StudentSystem.Data
{
    using System.Data.Entity;
    using StudentSystem.Models;
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            :base("StudentSystemDb")
        {

        }
        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Resource> Resources { get; set; }

    }
}
