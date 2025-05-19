using Finate.Application.Features.Commands.Candidates.PostCreateCandidateForm;
using Finate.Application.Features.Commands.Forms.PostCreateForm;
using Finate.Application.Features.Queries.Candidates.GetCandidateFormById;
using Finate.Application.Features.Queries.Candidates.GetCandidatesFormsByFilter;
using Finate.Domain.BaseValues;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Requests.Candidates.GetCandidatesFormsByFilter;
using Shared.Requests.Candidates.PostCreateCandidateForm;

namespace Finate.Web.Controllers;

public class CandidatesController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> FindCandidates(
        [FromQuery] GetCandidatesFormsByFilterRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetCandidatesFormsByFilterQuery(request);
        var response = await mediator.Send(query, cancellationToken);
        return View(response);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> CandidateForm([FromRoute] Guid candidateFormId, CancellationToken cancellationToken)
    {
        var query = new GetCandidateFormByIdQuery(candidateFormId);
        var response = await mediator.Send(query, cancellationToken);
        return View(response);
    }

    [HttpGet]
    [Authorize(Roles=$"{BaseRoles.CandidateRoleName}, {BaseRoles.AdminRoleName}")]
    public IActionResult CreateCandidateForm()
    {
        return View(new PostCreateCandidateFormRequest());
    }
    
    [HttpPost]
    [Authorize(Roles=$"{BaseRoles.CandidateRoleName}, {BaseRoles.AdminRoleName}")]
    public async Task<IActionResult> CreateCandidateForm(
        [FromForm] PostCreateCandidateFormRequest request,
        CancellationToken cancellationToken)
    {
        var createFormCommand = new PostCreateFormCommand(request);
        var createFormResponse = await mediator.Send(createFormCommand, cancellationToken);
        
        var createCandidateFormCommand = new PostCreateCandidateFormCommand(request, createFormResponse.CreatedFormId);
        var createCandidateFormResponse = await mediator.Send(createCandidateFormCommand, cancellationToken);
        
        return RedirectToAction("CandidateForm",
            "Candidates", 
            new object[] {createCandidateFormResponse.CreatedFormId});
    }
}