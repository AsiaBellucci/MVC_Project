using MVC_Project.Models.ValueTypes;
using System;
using System.Collections.Generic;

namespace MVC_Project.Models.Entities
{
    public partial class Courses
    {
        public Courses()
        {
            Lessons = new HashSet<Lessons>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public float Rating { get; set; }
        public Money FullPrice { get; set; }
        //public string FullPriceCurrency { get; set; }
        public Money CurrentPrice { get; set; }
        //public string CurrentPriceCurrency { get; set; }

        public virtual ICollection<Lessons> Lessons { get; set; }
    }
}
