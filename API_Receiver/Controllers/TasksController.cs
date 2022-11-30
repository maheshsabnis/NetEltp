using API_Receiver.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Receiver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        TasksReportContext context;

        public TasksController()
        {
            context = new TasksReportContext();
        }
        [HttpGet]
        public IActionResult Get() 
        {
            var tasks = context.JobTaskNews.ToList();   
            return Ok(tasks);
        }
    }
}
