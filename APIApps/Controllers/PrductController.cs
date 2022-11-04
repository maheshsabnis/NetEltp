using APIApps.Models;
using APIApps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApps.Controllers
{
     
    [Route("api/[controller]")]
   [ApiController]
    public class ProductController : ControllerBase
    {
        IDbAccessService<Product, int> prdService;
        /// <summary>
        /// Inject the Service Dependency
        /// </summary>
        public ProductController(IDbAccessService<Product,int> serv)
        {
            prdService = serv;
        }
        /// <summary>
        /// http://loalhost:7083/api/Product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await prdService.GetAsync();
            return Ok(result);  
        }
        /// <summary>
        /// The id is a Template Expression Parameter in the Request URL
        ///  http://loalhost:7083/api/Product/1001
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await prdService.GetAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Product prd)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    // Check if the ProductName is already present
                    var isProductExist = (await prdService.GetAsync())
                                            .Where(c => c.ProductName == prd.ProductName)
                                            .FirstOrDefault();
                    if (isProductExist != null)
                        throw new Exception($"There is alreay a Product with Name {prd.ProductName} exist.");
                        //return Conflict($"There is alreay a Product with Name {prd.ProductName} exist.");

                    var result = await prdService.CreateAsync(prd);
                    return Ok(result);
                }
                return BadRequest();
            //}
            //prdch (Exception ex)
            //{
            //    return Conflict(ex.Message);
            //}
            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,Product prd)
        {
            if (prd.ProductName.Length > 6)
                throw new Exception($"Sorry I cannot accept such a ength for Product NAme");
            var result = await prdService.UpdateAsync(id,prd);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await prdService.DeleteAsync(id);
             return Ok(result);
        }
    }
}
