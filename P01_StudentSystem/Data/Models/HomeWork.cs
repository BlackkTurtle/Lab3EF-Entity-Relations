namespace P01_StudentSystem.Data.Models
{
    public class HomeWork
    {
        public int HomeWorkId { get; set; }
        public string Content { get; set; }
        public ContentType ContentType { get; set; }
        public DateTime SubmissionTime { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public virtual Student Student { get; set; } = null!;
        public virtual Courses Course { get; set; } = null!;
    }
}
