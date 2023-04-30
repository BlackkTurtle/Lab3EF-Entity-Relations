﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P01_StudentSystem.Data;

#nullable disable

namespace P01_StudentSystem.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20230430203748_migrationtoDB")]
    partial class migrationtoDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("P01_StudentSystem.Data.Models.Courses", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("CourseId")
                        .HasName("PK__Courses");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("P01_StudentSystem.Data.Models.HomeWork", b =>
                {
                    b.Property<int>("HomeWorkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ContentType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SubmissionTime")
                        .HasColumnType("TEXT");

                    b.HasKey("HomeWorkId")
                        .HasName("PK__HomeWork");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("HomeWork");
                });

            modelBuilder.Entity("P01_StudentSystem.Data.Models.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("ResourceType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ResourceId")
                        .HasName("PK__Resource");

                    b.HasIndex("CourseId");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("P01_StudentSystem.Data.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegisteredOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId")
                        .HasName("PK__Students");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("P01_StudentSystem.Data.Models.StudentCourse", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId", "CourseId")
                        .HasName("PK__StudentCourse");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("P01_StudentSystem.Data.Models.HomeWork", b =>
                {
                    b.HasOne("P01_StudentSystem.Data.Models.Courses", "Course")
                        .WithMany("HomeWorks")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK_HomeWork_Courses");

                    b.HasOne("P01_StudentSystem.Data.Models.Student", "Student")
                        .WithMany("HomeWorks")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_HomeWork_Students");

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("P01_StudentSystem.Data.Models.Resource", b =>
                {
                    b.HasOne("P01_StudentSystem.Data.Models.Courses", "Course")
                        .WithMany("Resources")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK_Resources_Courses");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("P01_StudentSystem.Data.Models.StudentCourse", b =>
                {
                    b.HasOne("P01_StudentSystem.Data.Models.Courses", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("FK_StudentCouses_Courses");

                    b.HasOne("P01_StudentSystem.Data.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_StudentCouses_Students");

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("P01_StudentSystem.Data.Models.Courses", b =>
                {
                    b.Navigation("HomeWorks");

                    b.Navigation("Resources");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("P01_StudentSystem.Data.Models.Student", b =>
                {
                    b.Navigation("HomeWorks");

                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}