using APIApps.Models;
using APIApps.Services;
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
    [Route("api/[controller]")]
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await catService.GetAsync();
            return Ok(result);  
        }
    }
}
