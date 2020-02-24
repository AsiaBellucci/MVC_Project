using MVC_Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project.Models.ViewModels
{
    public class LessonViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }

        internal static LessonViewModel FromEntity(Lessons lesson)
        {
            return new LessonViewModel()
            {
                Id = lesson.Id,
                CourseId = lesson.CourseId,
                Title = lesson.Title,
                Description = lesson.Description,
                Duration = TimeSpan.Parse(lesson.Duration)
            };
        }
    }
}
