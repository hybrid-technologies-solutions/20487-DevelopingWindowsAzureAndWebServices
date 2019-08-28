using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EF_CodeFirst.Model
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Teacher CourseTeacher { get; set; }
        public virtual ICollection<CourseStudent> Students { get; set; } = new List<CourseStudent>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Course Id: {0}, Name: {1}", Id, Name));
            sb.AppendLine(string.Format("Teacher name: {0}, Salary: {1}", CourseTeacher.Name, CourseTeacher.Salary));
            sb.AppendLine("Students:");

            foreach (var item in Students.Select(e => e.Student))
	        {
                sb.AppendLine(string.Format("\tStudent name: {0}", item.Name));
	        }
            
            return sb.ToString();
        }
    }
}
