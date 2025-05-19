using Finate.Application.Features.Queries.Jobs.GetJobsFormsByFilter;
using Finate.Application.Features.Queries.Shop;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Requests.Jobs.GetJobsFormsByFilter;

namespace Finate.Web.Controllers
{
    [Route("[controller]")]
    public class ShopController : Controller
    {
        private readonly IMediator _mediator;

        public ShopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var query = new GetShop();
            var response = await _mediator.Send(query, cancellationToken);
            return View(response);
        }
    }
}

