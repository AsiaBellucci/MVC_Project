using Microsoft.EntityFrameworkCore;
using MVC_Project.Models.Services.Infrastructure;
using MVC_Project.Models.Services.Interfaces;
using MVC_Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project.Models.Services.Application
{
    public class EfCoreCourseService : ICourseService
    {
        private readonly MyCourseDbContext dbContext;
        public EfCoreCourseService(MyCourseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<CatalogoViewModel>> GetCoursesAsync()
        {
            #region vecchia versione
            //IQueryable<DetailViewModel> queryLinq = dbContext.Courses.AsNoTracking()
            //    .Select(course
            //    => DetailViewModel.FromEntity(course));
            //List<DetailViewModel> courses = await queryLinq.ToListAsync();
            //return courses;
            #endregion
            IQueryable<CatalogoViewModel> queryLinq = dbContext.Courses
                .AsNoTracking()
                .Select(course => new CatalogoViewModel
                {
                    Id = course.Id,
                    Title = course.Title,
                    ImagePath = course.ImagePath,
                    Author = course.Author,
                    Rating = Convert.ToDouble(course.Rating),
                    CurrentPrice = course.CurrentPrice,
                    FullPrice = course.FullPrice,
                });
            List<CatalogoViewModel> courses = await queryLinq.ToListAsync();

            return courses;
        }

        public async Task<DetailViewModel> GetDetailCourseAsync(int id)
        {
            #region Vecchia versione
            //IQueryable<DetailViewModel> queryLinq = dbContext.Courses
            //.AsNoTracking() //Si mette quando vogliamo solo leggere i dati;Indica a EFCore che vogliamo rinunciare al suo "change tracker", così da avere miglioramenti prestazionali.

            //.Include(course => course.Lessons)
            //.Where(course => course.Id == id)
            //.Select(course => DetailViewModel.FromEntity(course)); //Usando metodi statici come FromEntity, la query potrebbe essereinefficiente. Mantenere il mapping nella lambda oppure usare un extension method personalizzato

            //DetailViewModel viewModel = await queryLinq.SingleAsync();
            ////.FirstOrDefaultAsync(); //Restituisce null se l'elenco è vuoto e non solleva mai un'eccezione
            ////.SingleOrDefaultAsync(); //Tollera il fatto che l'elenco sia vuoto e in quel caso restituisce null, oppure se l'elenco contiene più di 1 elemento, solleva un'eccezione
            ////.FirstAsync(); //Restituisce il primo elemento, ma se l'elenco è vuoto solleva un'eccezione
            //return viewModel;
            #endregion

            DetailViewModel viewModel = await dbContext.Courses
                .AsNoTracking()
                .Where(course => course.Id == id)
                .Select(course => new DetailViewModel
                    {
                        Id = course.Id,
                        Title = course.Title,
                        Description = course.Description,
                        ImagePath = course.ImagePath, 
                        Rating = Convert.ToSingle(course.Rating), 
                        CurrentPrice = course.CurrentPrice, 
                        FullPrice = course.FullPrice,
                        Lessons = course.Lessons.Select(lesson => new LessonViewModel() 
                            {
                                Id = lesson.Id, 
                                Title = lesson.Title,
                                Description = lesson.Description, 
                                Duration = TimeSpan.Parse(lesson.Duration) 
                            }).ToList() 
                }).FirstOrDefaultAsync();
            return viewModel;
        }

    }
}
