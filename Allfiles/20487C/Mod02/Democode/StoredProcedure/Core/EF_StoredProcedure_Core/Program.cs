using EF_CodeFirst.Infra;
using EF_CodeFirst.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EF_Seed_Core
{
    class Program
    {
        private static DbContextOptions<SchoolContext> GetOptions()
            => new DbContextOptionsBuilder<SchoolContext>()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Database=Module_02_Demos;Integrated Security=True;")
            .Options;

        static void Main(string[] args)
        {
            SeedData();

            // Creating a SchoolContext to be used to access data
            using (var context = new SchoolContext(GetOptions()))
            {

                // Calculating the average grade for the course
                var averageGradeInCourse = (from c in context.Courses
                                            where c.Name == "WCF"
                                            select c.Students.Average(s => s.Grade)).Single();

                Console.WriteLine("Average grade for the course is {0}", averageGradeInCourse);

                // Adding 10 points to all the students in this course using Stored Procedure called spUpdateGrades, passing the course name and the grade change
                context.Database.ExecuteSqlCommand("spUpdateGrades @CourseName, @GradeChange",
                                                            new SqlParameter("@CourseName", "WCF"),
                                                            new SqlParameter("@GradeChange", 10));

                // Calculating the average grade for the course after the grades update
                var averageGradeInCourseAfterGradesUpdate = (from c in context.Courses
                                                             where c.Name == "WCF"
                                                             select c.Students.Average(s => s.Grade)).Single();

                Console.WriteLine("Average grade for the course is after 10 points upgrade is {0}", averageGradeInCourseAfterGradesUpdate);
            }
        }

        private static void SeedData()
        {
            using (var context = new SchoolContext(GetOptions()))
            {
                //Ensure database is created. Not compatible with migration
                context.Database.EnsureCreated();

                List<string> teacherNames = new List<string>() { "Kari Hensien", "Terry Adams", "Dan Park", "Peter Houston", "Lukas Keller", "Mathew Charles", "John Smith", "Andrew Davis", "Frank Miller", "Patrick Hines" };

                List<string> courseNames = new List<string>() { "WCF", "WFP", "ASP.NET", "Advanced .Net", ".Net Performance", "LINQ", "Entity Frameword", "Windows Azure", "Windows Phone 8", "Production Debugging" };

                // Generating ten courses
                for (int i = 0; i < 10; i++)
                {
                    var teacher = new Teacher() { Name = teacherNames[i], Salary = 100000 };
                    var course = new Course { Name = courseNames[i], CourseTeacher = teacher, Students = new List<Student>() };


                    Random rand = new Random(i);

                    // For each course, generating ten students and assigning them to the current course
                    for (int j = 0; j < 10; j++)
                    {
                        var student = new Student { Name = "Student_" + j, Grade = rand.Next(40, 90) };
                        course.Students.Add(student);
                    }
                    context.Courses.Add(course);
                    context.Teachers.Add(teacher);
                }

                // Saving the changes to the database
                context.SaveChanges();
            }
        }
    }
}
