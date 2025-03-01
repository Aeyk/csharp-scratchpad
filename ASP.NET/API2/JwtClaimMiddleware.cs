using System.Security.Claims;

public class JwtClaimMiddleware
{
    private readonly RequestDelegate _next;

    public JwtClaimMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (!string.IsNullOrEmpty(token))
            {
                var claimsIdentity = context.User.Identity as ClaimsIdentity;
                claimsIdentity?.AddClaim(new Claim("jwt", token));
            }
        }

        await _next(context);
    }
}