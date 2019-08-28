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
                    // Getting the WCF Course from the courses repository
                    Course WCFCourse = (from course in context.Courses
                                        where course.Name == "WCF"
                                        select course).Single();

                    // Creating two new students
                    Student firstStudent = new Student() { Name = "Thomas Andersen" };
                    Student secondStudent = new Student() { Name = "Terry Adams" };

                    // Adding the students to the WCF course
                    WCFCourse.Students.Add(new CourseStudent { Course = WCFCourse, Student = firstStudent });
                    WCFCourse.Students.Add(new CourseStudent { Course = WCFCourse, Student = secondStudent });

                    // Giving the course teacher a 1000$ raise
                    WCFCourse.CourseTeacher.Salary += 1000;

                    // Getting a student called Student_1
                    var studentToRemove = WCFCourse.Students.FirstOrDefault((student) => student.Student.Name == "Student_1");

                    // Remove a student from the WCF course
                    WCFCourse.Students.Remove(studentToRemove);

                    context.SaveChanges();

                    // Print the course details to the console
                    Console.WriteLine(WCFCourse);
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
                context.Database.EnsureCreated();
                if (context.Courses.Count() == 0 || context.Teachers.Count() == 0)
                {
                    List<string> teacherNames = new List<string>() { "Kari Hensien", "Terry Adams", "Dan Park", "Peter Houston", "Lukas Keller", "Mathew Charles", "John Smith", "Andrew Davis", "Frank Miller", "Patrick Hines" };

                    List<string> courseNames = new List<string>() { "WCF", "WPF", "ASP.NET", "Advanced .Net", ".Net Performance", "LINQ", "Entity Frameword", "Windows Azure", "Windows Phone 8", "Production Debugging" };

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
}
