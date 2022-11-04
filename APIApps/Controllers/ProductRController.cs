using APIApps.Models;
using APIApps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApps.Controllers
{
     
    [Route("api/[controller]")]
   [ApiController]
    public class ProductRController : ControllerBase
    {
        IDbAccessService<Product, int> prdService;
        /// <summary>
        /// Inject the Service Dependency
        /// </summary>
        public ProductRController(IDbAccessService<Product,int> serv)
        {
            prdService = serv;
        }
        /// <summary>
        /// http://loalhost:7083/api/Product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseObject> Get()
        {
            var responseObject = new ResponseObject();
            try
            {
               
                var result = await prdService.GetAsync();
                responseObject.Products = result.ToList();
                responseObject.StatusCode = 200;
                responseObject.Message = "Data Received Successfuly";
            }
            catch (Exception ex)
            {
                responseObject.StatusCode = 500;
                responseObject.Message = $"Some Error Occurred {ex.Message}";
               
            }
            return responseObject;
        }
        /// <summary>
        /// The id is a Template Expression Parameter in the Request URL
        ///  http://loalhost:7083/api/Product/1001
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ResponseObject> Get(int id)
        {
            var responseObject = new ResponseObject();
            try
            {
                var result = await prdService.GetAsync(id);
                responseObject.Product = result;
                responseObject.StatusCode = 200;
                responseObject.Message = "Data Received Successfuly";
            }
            catch (Exception ex)
            {
                responseObject.StatusCode = 500;
                responseObject.Message = $"Some Error Occurred {ex.Message}";
            }
            return responseObject;
        }
        [HttpPost]
        public async Task<ResponseObject> Post(Product prd)
        {
            var responseObject = new ResponseObject();
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await prdService.CreateAsync(prd);
                    responseObject.StatusCode = 201;
                    responseObject.Message = "Data Created Successfuly";
                }
                else
                {
                    responseObject.StatusCode = 500;
                    responseObject.Message = "Data CReation  Failed";
                }
                
            }
            catch(Exception ex)
            {
                responseObject.StatusCode = 500;
                responseObject.Message = $"Some Error Occurred while creating record {ex.Message}";
            }
            return responseObject;
        }
         
    }
}
