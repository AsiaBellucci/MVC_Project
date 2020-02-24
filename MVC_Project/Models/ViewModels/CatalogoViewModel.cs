using MVC_Project.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project.Models.ViewModels
{
    public class CatalogoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Author { get; set; }
        public double Rating { get; set; }
        public Money FullPrice { get; set; }
        public string Valuta { get; set; }
        public string ValutaCor { get; set; }
        public Money CurrentPrice { get; set; }
    }
}
