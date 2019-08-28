using EF_CodeFirst.Infra;
using EF_CodeFirst.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_Seed_Core
{
    class Program
    {
        private static DbContextOptions<SchoolContext> GetOptions()
            => new DbContextOptionsBuilder<SchoolContext>()
            .UseLazyLoadingProxies()
            .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Database=Module_02_Demos;Integrated Security=True;")
            .Options;

        static void Main(string[] args)
        {
            SeedData();
            // Creating a SchoolContext to be used to access data
            using (var context = new SchoolContext(GetOptions()))
            {
                try
                {
                    // Getting the courses list from the database
                    var courses = (from c in context.Courses
                                   select c);

                    // Writing the courses list to the console
                    foreach (var course in courses)
                    {
                        // For each course, writing the students list to the console
                        Console.WriteLine("Course: {0}", course.Name);
                        foreach (var student in course.Students)
                        {
                            Console.WriteLine("\tStudent name: {0}", student.Student.Name);
                        }
                    }

                    // Waiting for user input before closing the console window
                    Console.ReadLine();
                }
                finally
                {
                    context.Database.EnsureDeleted();
                }

            }
        }

        private static void SeedData()
        {
            using (var context = new SchoolContext(GetOptions()))
            {
                //Ensure database is created. Not compatible with migration
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                List<string> teacherNames = new List<string>() { "Kari Hensien", "Terry Adams", "Dan Park", "Peter Houston", "Lukas Keller", "Mathew Charles", "John Smith", "Andrew Davis", "Frank Miller", "Patrick Hines" };

                List<string> courseNames = new List<string>() { "WCF", "WFP", "ASP.NET", "Advanced .Net", ".Net Performance", "LINQ", "Entity Frameword", "Windows Azure", "Windows Phone 8", "Production Debugging" };

                // Generating ten courses
                for (int i = 0; i < 10; i++)
                {
                    var teacher = new Teacher() { Name = teacherNames[i], Salary = 100000 };
                    var course = new Course { Name = courseNames[i], CourseTeacher = teacher, Students = new List<CourseStudent>() };


                    Random rand = new Random(i);

                    // For each course, generating ten students and assigning them to the current course
                    for (int j = 0; j < 10; j++)
                    {
                        var student = new Student { Name = "Student_" + j, Grade = rand.Next(40, 90) };
                        course.Students.Add(new CourseStudent { Course = course, Student = student });
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
