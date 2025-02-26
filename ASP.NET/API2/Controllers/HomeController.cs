using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Policy = "Authenticated")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public Dictionary<string, string> Get()
    {
        return new Dictionary<string, string>()
        {
          {"Message", "Hello"},
          {"Name", "World"}
        };
    }
}
