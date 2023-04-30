namespace P01_StudentSystem.Data.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public virtual Student Student { get; set; } = null!;
        public virtual Courses Course { get; set; } = null!;
    }
}
