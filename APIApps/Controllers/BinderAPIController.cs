using APIApps.Models;
using APIApps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApps.Controllers
{
    /// <summary>
    /// The Routw will also take Action Name in http URL
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    //[ApiController]
    public class BinderAPIController : ControllerBase
    {
        IDbAccessService<Category, int> catServ;

        public BinderAPIController(IDbAccessService<Category, int> catServ)
        {
            this.catServ = catServ;
        }
        /// <summary>
        /// http://localhost:7083/api/BinderAPI/postparam
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="CategoryName"></param>
        /// <param name="BasePrice"></param>
        /// <returns></returns>
        [HttpPost]
        // THis Action NAme will be used by the CLient
        [ActionName("postparam")]
        public async Task<IActionResult> PostParameters(int CategoryId, string CategoryName, decimal BasePrice)
        {
               
            return Ok();
        }
        /// <summary>
        /// https://localhost:7083/api/BinderAPI/postquery?CategoryId=1006&CategoryName=TestCat&BasePrice=444
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        [HttpPost]
        // THis Action NAme will be used by the CLient
        [ActionName("postquery")]
        public async Task<IActionResult> PostFromQuery([FromQuery]Category cat)
        {

            return Ok();
        }
        /// <summary>
        /// https://localhost:7083/api/BinderAPI/postrout/1006/TestCat/444
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        [HttpPost("{categoryid}/{categoryname}/{baseprice}")]
        // THis Action NAme will be used by the CLient
        [ActionName("postroute")]
        public async Task<IActionResult> PostFromRoute([FromRoute] Category cat)
        {

            return Ok();
        }
    }
}
