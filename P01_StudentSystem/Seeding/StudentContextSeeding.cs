using P01_StudentSystem.Data;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Seeding
{
    public class StudentContextSeeding
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<StudentContext>();
                if (!context.Students.Any())
                {
                    context.Students.AddRange(new Student()
                    {
                        StudentName = "DFFWREW",
                        PhoneNumber="1234567890",
                        RegisteredOn = DateTime.Now,
                    });
                }
                context.SaveChanges();
                if (!context.courses.Any())
                {
                    context.AddRange(new Courses()
                    {
                        CourseName="fefefefe",
                        Description="fdsfdwfw",
                        StartDate=DateTime.Now,
                        EndDate=DateTime.Now,
                        Price=2345
                    });
                }
                context.SaveChanges();
                if (!context.HomeWork.Any())
                {
                    context.HomeWork.AddRange(new HomeWork()
                    {
                        Content="fdadfsa",
                        ContentType=ContentType.Pdf,
                        SubmissionTime=DateTime.Now,
                        StudentId=1,
                        CourseId=1
                    });
                }
                context.SaveChanges();
                if (!context.Resource.Any())
                {
                    context.Resource.AddRange(new Resource()
                    {
                        ResourceName = "gegrt",
                        URL="frefer",
                        ResourceType=ResourceType.Document,
                        CourseId = 1
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
