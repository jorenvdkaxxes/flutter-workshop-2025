using Identity.Application;
using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure;

public class User : IdentityUser, IUser
{
    public User(string email)
        : base(email)
        => Email = email;
}