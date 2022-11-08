using Microsoft.AspNetCore.Mvc;
using Coditas.EComm.Entities;
using Coditas.EComm.Repositories;
using System.Runtime.InteropServices;

namespace MVC_Apps.Controllers
{
    public class CategoryController : Controller
    {
        IDbRepository<Category, int> catRepo;
        /// <summary>
        /// Ijecting the Depednency
        /// </summary>
        /// <param name="ctaRepo"></param>
        public CategoryController(IDbRepository<Category, int> catRepo)
        {
            this.catRepo = catRepo;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var records = await catRepo.GetAsync();
                // THis will return an Index.cshtml View from
                // Category Sub-Folder of the Views folder
                // and pass the records (Categories) to it
                return View(records);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> Create()
        {
            var category = new Category();
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            try
            {
                var respose = await catRepo.CreateAsync(category);
                // Return to Index Action Method in Same
                // Controller
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> Edit(int id)
        { 
            var record = await catRepo.GetAsync(id);
            return View(record);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            try
            {
                var result = await catRepo.UpdateAsync(id,category);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
