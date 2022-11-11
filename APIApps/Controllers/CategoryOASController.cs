using APIApps.Models;
using APIApps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Mime;

namespace APIApps.Controllers
{
    [Route("api/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class CategoryOASController : ControllerBase
    {
        IDbAccessService<Category, int> catDbAccess;

        public CategoryOASController(IDbAccessService<Category, int> catDbAccess)
        {
            this.catDbAccess = catDbAccess;
        }
        /// <summary>
        /// MOdify the HTTP Action Method to
        /// return Managed Object Instead of HttpResponseMessage (IActionResult)
        /// </summary>
        /// <returns></returns>
        [HttpGet("/getcategoties")]
        public async Task<IEnumerable<Category>> Get()
        { 
            var result = await catDbAccess.GetAsync();
            return result;
        }

        [HttpPost("/createcategory")]
        public async Task<Category> Post(Category category)
        {
            var result = await catDbAccess.CreateAsync(category);   
            return result;
        }
    }
}
