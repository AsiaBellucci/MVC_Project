using System;
using System.Collections.Generic;

namespace MVC_Project.Models.Entities
{
    public partial class Apples
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int? Weight { get; set; }
        public string Variety { get; set; }
        public string Origin { get; set; }
    }
}
