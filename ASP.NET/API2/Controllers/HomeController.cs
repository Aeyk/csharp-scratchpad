using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

[ApiController]
[Route("[controller]/[action]")]
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
    [HttpGet]
    public IDictionary<string, IEnumerable<string>> Groups() {
        ArraySegment<string> claims = (HttpContext.User.Identity as ClaimsIdentity ?? new ClaimsIdentity())
            .Claims
            .Where(c => c.Type == "groups")
            .Select(c => c.Value)
            .ToArray() ;
        return new Dictionary<string, IEnumerable<string>>()
        {
            {"groups", claims },
        };
    }

    [HttpGet]
    [Authorize(Policy = "Administrator")]
    public Dictionary<string, bool> IsAdmin()
    {
        return new Dictionary<string, bool>()
        {
          {"Administrator", true}
        };
    }
}
