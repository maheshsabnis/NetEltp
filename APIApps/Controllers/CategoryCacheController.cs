using APIApps.Models;
using APIApps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace APIApps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryCacheController : ControllerBase
    {
        IMemoryCache memoryCache;
        IDbAccessService<Category, int> catDbAccess;
        private string cacheKey = "Categories";

        public CategoryCacheController(IMemoryCache memoryCache, IDbAccessService<Category, int> catDbAccess)
        {
            this.memoryCache = memoryCache;
            this.catDbAccess = catDbAccess;
        }

        [HttpGet("/getcats")]
        public async Task <ResponseObject> GetAsync()
        {
            ResponseObject response =  new ResponseObject ();
            List<Category> categories = null;
            try
            {
                // 1. Try to Get data from Cache
                var isDataAvaiableInCache = memoryCache.TryGetValue(cacheKey, out categories);
                // 2. If Null then REad data from Db Server and Add in cache
                if (!isDataAvaiableInCache)
                {
                    categories = (await catDbAccess.GetAsync()).ToList();
                    response.Categories = categories;
                    response.Message = "Data is received from Database";
                    // 2.a. define Options for data in cache
                    var memoryCacheOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));
                    // 2.b. Add Data in Cache
                    memoryCache.Set(cacheKey, categories,
                        memoryCacheOptions);
                }
                else
                { 
                  response.Categories = categories;
                  response.Message = "Data is Received from Cache"; 
                }
                
                // 3. Return Response
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
