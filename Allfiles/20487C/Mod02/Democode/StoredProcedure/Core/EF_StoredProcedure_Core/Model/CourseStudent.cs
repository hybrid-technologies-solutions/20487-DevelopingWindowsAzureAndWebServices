using System;
using System.Collections.Generic;
using System.Text;

namespace EF_CodeFirst.Model
{
    public class CourseStudent
    {
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

        public virtual int StudentId { get; set; }
        public virtual int CourseId { get; set; }
    }
}
