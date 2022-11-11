using Microsoft.AspNetCore.Mvc;
using Coditas.EComm.Entities;
using Coditas.EComm.Repositories;

namespace MVC_Apps.Controllers
{
    public class CategoryProductController : Controller
    {
        IDbRepository<Category, int> catRepo;
        IDbRepository<Product, int> prdRepo;
        public CategoryProductController(IDbRepository<Category, int> catRepo, IDbRepository<Product, int> prdRepo)
        {
            this.catRepo = catRepo;
            this.prdRepo = prdRepo;
        }

        public async Task<IActionResult> Index(int? id)
        {
            List<Category> categories = null;
            List<Product> products = null;
            Tuple<List<Category>, List<Product>> tuple = null;
            
            categories = (await catRepo.GetAsync()).ToList();
            
            if (id == null || id == 0)
            {
                products = (await prdRepo.GetAsync()).ToList();
            }
            else
            {
                products = (await prdRepo.GetAsync()).Where(p => p.CategoryId == id).ToList();
            }

             tuple = new Tuple<List<Category>, List<Product>>(categories,products);

            return View(tuple);
        }

        public IActionResult ShowDetails(int? id)
        {
            return RedirectToAction("Index", new { id = id });
        }
    }
}
