using Microsoft.AspNetCore.Mvc;
using Coditas.EComm.Entities;
using Coditas.EComm.Repositories;
using System.Runtime.InteropServices;
using MVC_Apps.Models;
using MVC_Apps.CustomFilters;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Apps.CustomSessionExtensions;

namespace MVC_Apps.Controllers
{
    /// <summary>
    /// Apply Filter at Controller
    /// </summary>
    /// 
    //[LogRequest]
    public class ProductController : Controller
    {
        IDbRepository<Product, int> prdRepo;
        IDbRepository<Category, int> catRepo;
        /// <summary>
        /// Ijecting the Depednency
        /// </summary>
        /// <param name="ctaRepo"></param>
        /// 
        public ProductController(IDbRepository<Product, int> prdRepo, IDbRepository<Category, int> catRepo)
        {
            this.prdRepo = prdRepo;
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
            IEnumerable<Product> records = null;
            try
            {
                // REad CategoryId from Session
                //   int CategoryId = Convert.ToInt32( HttpContext.Session.GetInt32("CategoryId"));


                // REading Data from TempData
                if (TempData.Keys.Count > 0)
                {
                    int CategoryId = Convert.ToInt32(TempData["CategoryId"]);


                    var cat = HttpContext.Session.GetObject<Category>("Cat");

                    if (CategoryId == 0)
                    {
                        records = await prdRepo.GetAsync();
                    }
                    else
                    {
                        records = (await prdRepo.GetAsync()).Where(p => p.CategoryId == CategoryId).ToList();
                    }
                }

                // INform the Service to Maintain The TempData with
                // either all keys or a Specific Key
                TempData.Keep();
                
                return View(records);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> Create()
        {
            var x = TempData["CategoryId"];

            var product = new Product();
            // PAss LIst of Categories to Create.cshtml 
            List<Category> categories = (await catRepo.GetAsync()).ToList();

            List<SelectListItem> categoryItem= new List<SelectListItem>();
            // Add Data from "categories" to "categoryItem"
            foreach (var cat in categories)
            {
                categoryItem.Add(new SelectListItem(cat.CategoryName, cat.CategoryId.ToString()));
            }
            // USe ViewBag to pass Data to UI
            ViewBag.Categories = categoryItem;
            
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
       
                if (ModelState.IsValid)
                {
                    var respose = await prdRepo.CreateAsync(product);
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    // Stay on Same View
                    // THis will Show Error Messages
                    return View(product);
                }
               
             
        }

        public async Task<IActionResult> Edit(int id)
        {
            var x = TempData["CategoryId"];
            var record = await prdRepo.GetAsync(id);
            return View(record);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            try
            {
                var result = await prdRepo.UpdateAsync(id,product);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
