using MVC_Project.Models.Entities;
using MVC_Project.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project.Models.ViewModels
{
    public class DetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public double Rating { get; set; }
        public Money FullPrice { get; set; }
        public string Valuta { get; set; }
        public string ValutaCor { get; set; }
        public Money CurrentPrice { get; set; }

        public string Description { get; set; }
        public List<LessonViewModel> Lessons { get; set; }
        //Proprietà solo in get, che calcola il totale della durata delle lezioni public TimeSpan TotalCourseDuration { get => TimeSpan.FromSeconds(Lessons?.Sum(l => l.Duration.TotalSeconds) ?? 0); }

        public TimeSpan TotalCourseDuration
        {
            get => TimeSpan.FromSeconds(Lessons?.Sum(l => l.Duration.TotalSeconds) ?? 0);
        }
        public static  DetailViewModel FromEntity(Courses course) { 
            return new DetailViewModel 
            {
                Id = course.Id, Title = course.Title, 
                Description = course.Description,
                ImagePath = course.ImagePath,
                FullPrice = course.FullPrice,
                CurrentPrice = course.CurrentPrice, 
                Lessons = course.Lessons.Select(lesson => LessonViewModel
                                        .FromEntity(lesson)).ToList() }; }

    }
}
