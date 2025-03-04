using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
[Authorize]
public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> logger;
    private readonly TaskContext taskContext;

    public TaskController(ILogger<TaskController> logger, TaskContext taskContext)
    {
        this.logger = logger;
        this.taskContext = taskContext;
    }

    [HttpGet]
    public List<TaskDto> Get()
    {
        return taskContext.Tasks.ToList();
    }

    
    [HttpPost]
    public async Task<TaskDto> Create(TaskDto task)
    {
        await taskContext.Tasks.AddAsync(task);
        
        task.Creator = new UserDto() {
            Name = HttpContext.User.Identity.Name ?? HttpContext.User.Identities.ToString()
        };
        
        taskContext.SaveChanges();
        return task;
    }
    
}
