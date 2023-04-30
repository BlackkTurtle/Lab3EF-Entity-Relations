using System.Numerics;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }
        public DbSet<Courses> courses => Set<Courses>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<HomeWork> HomeWork => Set<HomeWork>();
        public DbSet<Resource> Resource => Set<Resource>();
        public DbSet<StudentCourse> StudentCourse => Set<StudentCourse>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId).HasName("PK__Courses");
                entity.Property(e => e.CourseName).HasMaxLength(80);
                entity.Property(e => e.Description);
                entity.Property(e => e.StartDate);
                entity.Property(e => e.EndDate);
                entity.Property(e=>e.Price);
            });

            modelBuilder.Entity<HomeWork>(entity =>
            {
                entity.HasKey(e => e.HomeWorkId).HasName("PK__HomeWork");

                entity.Property(e => e.Content);
                entity.Property(e => e.ContentType);
                entity.Property(e => e.SubmissionTime);
                entity.HasOne(d => d.Student).WithMany(p => p.HomeWorks)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HomeWork_Students");
                entity.HasOne(d => d.Course).WithMany(p => p.HomeWorks)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HomeWork_Courses");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId).HasName("PK__Resource");

                entity.Property(e => e.ResourceName).HasMaxLength(50);
                entity.Property(e => e.ResourceType);
                entity.Property(e => e.URL);
                entity.HasOne(d => d.Course).WithMany(p => p.Resources)
                   .HasForeignKey(d => d.CourseId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Resources_Courses");
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId }).HasName("PK__StudentCourse");
                entity.HasOne(d => d.Student).WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentCouses_Students");
                entity.HasOne(d => d.Course).WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentCouses_Courses");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId).HasName("PK__Students");

                entity.Property(e => e.StudentName).HasMaxLength(100);
                entity.Property(e => e.Birthday);
                entity.Property(e => e.RegisteredOn);
                entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            });
        }
    }
}
