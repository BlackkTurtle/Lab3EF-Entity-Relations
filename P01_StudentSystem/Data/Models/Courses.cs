namespace P01_StudentSystem.Data.Models
{
    public class Courses
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public virtual ICollection<HomeWork> HomeWorks { get; } = new List<HomeWork>();
        public virtual ICollection<StudentCourse> StudentCourses { get; } = new List<StudentCourse>();
        public virtual ICollection<Resource> Resources { get; } = new List<Resource>();
    }
}
