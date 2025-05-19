using Finate.Application.Features.Commands.Shop;
using Finate.Application.Features.Queries.Shop;
using Finate.Application.Features.Queries.Shop.Commands;
using Finate.Application.Features.Queries.Shop.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Finate.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
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

        [HttpGet]
        public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetProductCardQuery { Id = id };
            var response = await _mediator.Send(query, cancellationToken);
            return View(response);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCardCommand command, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            var id = await _mediator.Send(command, cancellationToken);
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetProductCardQuery { Id = id };
            var response = await _mediator.Send(query, cancellationToken);
            if (response == null)
            {
                return NotFound();
            }

            var command = new Application.Features.Commands.Shop.UpdateProductCardCommand
            {
                Id = response.Id,
                CardName = response.CardName,
                Description = response.Description,
                ImageSrc = response.ImageSrc,
                Price = response.Price
            };

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Application.Features.Commands.Shop.UpdateProductCardCommand command, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command, cancellationToken);
            //return RedirectToAction(nameof(Details), new { id = command.Id });
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteProductCardCommand { Id = id };
            await _mediator.Send(command, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
}
