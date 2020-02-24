using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models.Services.Interfaces;
using MVC_Project.Models.ViewModels;

namespace MVC_Project.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ICourseService _catalogo;

        public CatalogoController(ICourseService catalogo)
        {
            this._catalogo = catalogo;
        }
        // GET: Catalogo
        public async Task<ActionResult> IndexAsync()
        {
            ICourseService catalogo = _catalogo;
            List<CatalogoViewModel> listaCatalogo = await catalogo.GetCoursesAsync(); //.GetCatalogoAsync
            return View(listaCatalogo);
        }

        // GET: Catalogo/Details/5
        public async Task<ActionResult> DetailsAsync(string Id)
        {
            int IntId = Convert.ToInt32(Id);
            ICourseService catalogo = _catalogo;
            DetailViewModel Dettaglio = await catalogo.GetDetailCourseAsync(IntId); //.GetDettaglioAsync(Id)
            return View(Dettaglio);
        }

        // GET: Catalogo/Create
        public ActionResult Create()
        {
            return View();
        }








        // POST: Catalogo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: Catalogo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Catalogo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: Catalogo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Catalogo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}