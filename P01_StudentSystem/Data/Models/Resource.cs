namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string URL { get; set; }
        public ResourceType ResourceType { get; set; }
        public int CourseId { get; set; }
        public virtual Courses Course { get; set; } = null!;
    }
}
