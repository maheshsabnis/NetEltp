using APIApps.Models;
using APIApps.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApps.Controllers
{
    /// <summary>
    /// The ROute URL Expression
    /// api/[controller], the 'api' a word that represents the URL for WEB API
    /// the '[controller]' is a placeholder for the API Controller class name (w/o) 'Controller' word. E.g. If class CategoryController is a class name, then
    /// [controller] will be 'Category'
    /// ApiController, the attribute thta represts the current class as API Controller
    /// and if a HTTP Request contains JSON data for POST and PUT in Body, then
    /// APiCOntroller will map the JSON data to CLR  object as input parameter to POST and PUT method 
    /// 
    /// ControllerBase: The base class for API used for following
    /// 1. Mapping the HTTP REqust to Corresponding method of COntroller class
    /// 2. Data VAlidations
    /// 3. Checking Authetication and Authorization
    /// 4. Handling Exceptions
    /// 5. HAndling the API access usinf Cross-Origin-Resource-Sharing aka (CORS)
    /// 6. Generating Responses
    ///     - Ok(), NotFound(), Create(), BadRequest(), NoContent(), etc.
    /// </summary>
    /// 
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IDbAccessService<Category, int> catService;
        /// <summary>
        /// Inject the Service Dependency
        /// </summary>
        public CategoryController(IDbAccessService<Category,int> serv)
        {
            catService = serv;
        }
        /// <summary>
        /// http://loalhost:7083/api/Category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await catService.GetAsync();
            return Ok(result);  
        }
        /// <summary>
        /// The id is a Template Expression Parameter in the Request URL
        ///  http://loalhost:7083/api/Category/1001
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await catService.GetAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Category cat)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    // Check if the CategoryName is already present
                    var isCategoryExist = (await catService.GetAsync())
                                            .Where(c => c.CategoryName == cat.CategoryName)
                                            .FirstOrDefault();
                    if (isCategoryExist != null)
                        throw new Exception("There is alreay a Category with Name {cat.CategoryName} exist.");
                        //return Conflict($"There is alreay a Category with Name {cat.CategoryName} exist.");

                    var result = await catService.CreateAsync(cat);
                    return Ok(result);
                }
                return BadRequest();
            //}
            //catch (Exception ex)
            //{
            //    return Conflict(ex.Message);
            //}
            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,Category cat)
        {
            if (cat.CategoryName.Length > 6)
                throw new Exception($"Sorry I cannot accept such a ength for Category NAme");
            var result = await catService.UpdateAsync(id,cat);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await catService.DeleteAsync(id);
             return Ok(result);
        }
    }
}
