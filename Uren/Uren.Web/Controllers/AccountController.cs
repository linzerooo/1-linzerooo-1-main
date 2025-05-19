using Finate.Application.Features.Commands.Account.PatchEditMyProfile;
using Finate.Application.Features.Queries.Account.GetMyProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Requests.Account.PatchEditMyProfile;

namespace Finate.Web.Controllers;

[Authorize]
public class AccountController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> MyProfile(CancellationToken cancellationToken)
    {
        var query = new GetMyProfileQuery();
        var response = await mediator.Send(query, cancellationToken);
        return View(response);
    }

    [HttpGet]
    public IActionResult EditMyProfile() => View(new PatchEditMyProfileRequest());
    
    [HttpPost]
    public async Task<IActionResult> EditMyProfile(
        [FromForm] PatchEditMyProfileRequest request,
        CancellationToken cancellationToken)
    {
        var command = new PatchEditMyProfileCommand(request);
        await mediator.Send(command, cancellationToken);
        
        return RedirectToAction("MyProfile", "Account");
    }
}