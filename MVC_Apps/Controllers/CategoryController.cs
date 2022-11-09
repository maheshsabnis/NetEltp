using Microsoft.AspNetCore.Mvc;
using Coditas.EComm.Entities;
using Coditas.EComm.Repositories;
using System.Runtime.InteropServices;
using MVC_Apps.Models;
using MVC_Apps.CustomFilters;

namespace MVC_Apps.Controllers
{
    /// <summary>
    /// Apply Filter at Controller
    /// </summary>
    /// 
    //[LogRequest]
    public class CategoryController : Controller
    {
        IDbRepository<Category, int> catRepo;
        /// <summary>
        /// Ijecting the Depednency
        /// </summary>
        /// <param name="ctaRepo"></param>
        /// 
        public CategoryController(IDbRepository<Category, int> catRepo)
        {
            this.catRepo = catRepo;
        }
        /// <summary>
        /// Apply Filter at Action Method
        /// </summary>
        /// <returns></returns>
        /// 
       // [LogRequest]
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
            //try
            //{
                if (ModelState.IsValid)
                {
                    var respose = await catRepo.CreateAsync(category);
                    if (category.BasePrice < 0)
                        throw new Exception("Base Price Cannot be -ve");
                    // Return to Index Action Method in Same
                    // Controller
                    return RedirectToAction("Index");
                }
                else
                {
                    // Stay on Same View
                    // THis will Show Error Messages
                    return View(category);
                }
               
            //}
            //catch (Exception ex)
            //{
            //    return View("Error", new ErrorViewModel() 
            //    {
            //        //ControllerName = "Category",
            //        //ActonName = "Create",
            //        //ErrorMessage = ex.Message
            //        // REad controller and action from RouteData
            //        ControllerName = this.RouteData.Values["controller"].ToString(),
            //        ActonName = this.RouteData.Values["action"].ToString(),
            //        ErrorMessage = ex.Message
            //    });
            //}
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
