using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        [MinLength(10)]
        public string? PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime ? Birthday { get; set; }
        public virtual ICollection<HomeWork> HomeWorks { get; } = new List<HomeWork>();
        public virtual ICollection<StudentCourse> StudentCourses { get; } = new List<StudentCourse>();
    }
}
