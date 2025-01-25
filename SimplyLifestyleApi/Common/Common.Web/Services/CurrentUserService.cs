using System.Security.Claims;
using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Common.Web;

public class CurrentUserService : ICurrentUser
{
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext?.User;

        if (user == null)
        {
            throw new InvalidOperationException("This request does not have an authenticated user.");
        }

        UserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public string UserId { get; }
}