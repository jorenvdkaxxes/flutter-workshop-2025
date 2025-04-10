using Common.Web;
using Identity.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Web;

public class IdentityController : ApiController
{
    [HttpPost]
    public async Task<ActionResult> Register(
        RegisterUserCommand command)
        => await Send(command);

    [HttpPost]
    public async Task<ActionResult<UserResponseModel>> Login(
        LoginUserCommand command)
        => await Send(command);

    [HttpPut]
    [Authorize]
    public async Task<ActionResult> ChangePassword(
        ChangePasswordCommand command)
        => await Send(command);
}