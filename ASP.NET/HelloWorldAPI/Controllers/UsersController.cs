namespace HelloWorldAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using HelloWorldAPI.Authorization;
using HelloWorldAPI.Models;
using HelloWorldAPI.Services;

[ApiController]
[Authorize]
[Route("api/v1")]
public class UsersController : ControllerBase
{
  private IUserService _userService;
  private IJwtUtils _jwtUtils;

  public UsersController(IUserService userService, IJwtUtils jwtUtils)
  {
    _userService = userService;
    _jwtUtils = jwtUtils;
  }

  [AllowAnonymous]
  [HttpPost, Route("login")]
  public IActionResult Authenticate(AuthenticateRequest model)
  {
    var response = _userService.Authenticate(model);

    if (response == null)
      return BadRequest(new { message = "Username or password is incorrect" });

    return Ok(response);
  }

  [Authorize, HttpGet, Route("whoami")]
  public IActionResult WhoAmI()
  {
    if (Request.Headers.TryGetValue("Authorization", out var bearer))
    {
      var userId =
        _jwtUtils.ValidateJwtToken(bearer);
      if (null != userId)
        return Ok(_userService.GetById((int)userId));
    }
    return BadRequest("No such user.");
  }

  // [HttpGet]
  // public IActionResult GetAll()
  // {
  //     var users = _userService.GetAll();
  //     return Ok(users);
  // }
}
