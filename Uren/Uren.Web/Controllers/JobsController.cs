using Finate.Application.Features.Commands.Forms.PostCreateForm;
using Finate.Application.Features.Commands.Jobs.PostCreateJobForm;
using Finate.Application.Features.Queries.Jobs.GetJobFormById;
using Finate.Application.Features.Queries.Jobs.GetJobsFormsByFilter;
using Finate.Domain.BaseValues;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Requests.Jobs.GetJobsFormsByFilter;
using Shared.Requests.Jobs.PostCreateJobForm;

namespace Finate.Web.Controllers;

public class JobsController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> FindJobs(
        [FromQuery] GetJobsFormsByFilterRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetJobsFormsByFilterQuery(request);
        var response = await mediator.Send(query, cancellationToken);
        return View(response);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> JobForm(
        [FromRoute] Guid jobFormId,
        CancellationToken cancellationToken)
    {
        var query = new GetJobFormByIdQuery(jobFormId);
        var response = await mediator.Send(query, cancellationToken);
        return View(response);
    }
    
    [HttpGet]
    [Authorize(Roles=$"{BaseRoles.EmployerRoleName}, {BaseRoles.AdminRoleName}")]
    public IActionResult CreateJobForm()
    {
        return View(new PostCreateJobFormRequest());
    }
    
    [HttpPost]
    [Authorize(Roles=$"{BaseRoles.EmployerRoleName}, {BaseRoles.AdminRoleName}")]
    public async Task<IActionResult> CreateJobForm(
        [FromForm] PostCreateJobFormRequest request,
        CancellationToken cancellationToken)
    {
        var createFormCommand = new PostCreateFormCommand(request);
        var createFormResponse = await mediator.Send(createFormCommand, cancellationToken);
        
        var createJobFormCommand = new PostCreateJobFormCommand(request, createFormResponse.CreatedFormId);
        var createJobFormResponse = await mediator.Send(createJobFormCommand, cancellationToken);
        
        return RedirectToAction("CandidateForm",
            "Candidates", 
            new object[] {createJobFormResponse.CreatedFormId});
    }
}