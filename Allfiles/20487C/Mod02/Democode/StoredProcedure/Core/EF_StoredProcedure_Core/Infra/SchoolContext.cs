using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_CodeFirst.Model;
using Microsoft.EntityFrameworkCore;

namespace EF_CodeFirst.Infra
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var personEntity = modelBuilder.Entity<Person>();
            personEntity.ToTable("Persons");

            var studentEntity = modelBuilder.Entity<Student>();
            studentEntity.HasMany(e => e.Courses);

            var teacherEntity = modelBuilder.Entity<Teacher>();
            teacherEntity.ToTable("Teachers");

            var courseEntity = modelBuilder.Entity<Course>();
            courseEntity.HasOne(e => e.CourseTeacher);
            courseEntity.HasMany(e => e.Students);

            var studentCourse = modelBuilder.Entity<CourseStudent>();
            studentCourse.HasOne(e => e.Student).WithMany(e => e.Courses);
            studentCourse.HasOne(e => e.Course).WithMany(e => e.Students);
            studentCourse.HasKey(e => new { e.CourseId, e.StudentId });
        }
    }
}
