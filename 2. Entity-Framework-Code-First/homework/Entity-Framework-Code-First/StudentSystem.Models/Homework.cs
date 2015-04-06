namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        public int HomeworkId { get; set; }

        [MaxLength(250)]
        public string Content { get; set; }

        [Required]
        public HomeworkType Type { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

    }
}
