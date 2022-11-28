using Microsoft.AspNetCore.Mvc;
using Coditas.EComm.Entities;
using Coditas.EComm.Repositories;
namespace MVC_Apps.Controllers
{
    public class SPAController : Controller
    {
        IDbRepository<Category, int> repository;
        public SPAController(IDbRepository<Category, int> repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var categories = await repository.GetAsync();
            return PartialView("_List", categories);
        }
        public IActionResult Create()
        {
            var category = new Category();  
            return PartialView("_Create",category);
        }
    }
}
