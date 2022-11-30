using API_Sender.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Sender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTaskController : ControllerBase
    {
        TasksContext context;
        public JobTaskController(TasksContext ctx)
        {
            context= ctx;   
        }

        [HttpPost]
        public IActionResult Post(JobTask task)
        {
            var res = context.JobTasks.Add(task);
            context.SaveChanges();
            return Ok(res.Entity);
        }
    }
}
