using APIApps.Models;
using APIApps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIApps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombineController : ControllerBase
    {
        IDbAccessService<Category, int> catServ;
        IDbAccessService<Product, int> prdServ;
        public CombineController(IDbAccessService<Category, int> catServ, IDbAccessService<Product, int> prdServ)
        {
            this.catServ = catServ;
            this.prdServ = prdServ;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var categories = await catServ.GetAsync();
            //var products = await prdServ.GetAsync();

            var categories = (from cat in await catServ.GetAsync()
                              select new Category
                              {
                                  CategoryId = cat.CategoryId,
                                  CategoryName = cat.CategoryName,
                                  BasePrice = cat.BasePrice
                              }).ToList();
            var products = (from prd in await prdServ.GetAsync()
                           select new Product() 
                           {
                             ProductUniqueId = prd.ProductUniqueId,
                             ProductId = prd.ProductId,
                             ProductName = prd.ProductName,
                             Price = prd.Price,
                             Manufacturer = prd.Manufacturer
                           }).ToList(); 

            var combineModels = new CategotyProduct()
            {
                Categories = categories.ToList(),
                 Products = products.ToList()
            };
            // USing Anonymous Type
            //return Ok(new { cats = categories, prds = products});
            return Ok(combineModels);
        }
    }
}
