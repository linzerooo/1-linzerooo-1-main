using Finate.Application.Features.Commands.Contact.PostSendEmail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Requests.Contact.GetSendEmail;
using Shared.Requests.Contact.PostSendEmail;

namespace Finate.Web.Controllers;

[AllowAnonymous]
public class ContactController(IMediator mediator)
    : Controller
{
    [HttpPost]
    public async Task<IActionResult> SendEmail([FromBody] PostSendEmailRequest request,
        CancellationToken cancellationToken)
    {
        var command = new PostSendEmailCommand(request);
        var response = await mediator.Send(command, cancellationToken);

        if (response.WasSentToCandidate)
            return RedirectToAction(
                "CandidateForm", "Candidates", new object[] { request.FormId });

        return RedirectToAction("JobForm", "Jobs", new object[] { request.FormId });
    }

    [HttpGet]
    public IActionResult SendEmail([FromRoute] GetSendEmailRequest request) 
        => View(new PostSendEmailRequest
        {
            FormId = request.FormId,
            NeedSendToCandidate = request.IsCandidateForm
        });
}