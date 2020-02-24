using System;
using System.Collections.Generic;

namespace MVC_Project.Models.Entities
{
    public partial class Lessons
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }

        public virtual Courses Course { get; set; }
    }
}
