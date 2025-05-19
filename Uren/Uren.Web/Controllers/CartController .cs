using Finate.Application.Features.Commands.Card;
using Finate.Application.Features.Commands.Card.Query;
using Finate.Application.Features.Queries.Shop;
using Finate.Application.Interfaces;
using Finate.Web;
using Finate.Web.Views.Cart;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class CartController : Controller
{
    private readonly IMediator _mediator;

    public CartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("AddToCart")]
    public async Task<IActionResult> AddToCart(Guid cardId, int quantity)
    {
        var cardDto = new AddToCartDto { ProductCardId = cardId, Quantity = quantity };

        var command = new AddToCartCommand { Dto = cardDto, Quantity = quantity };
        await _mediator.Send(command);
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    [Route("")]
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var query = new GetCartItemsQuery();
        var cartItems = await _mediator.Send(query);
        return View(cartItems);
    }


    [HttpPost]
    [Route("ClearCart")]
    public async Task<IActionResult> ClearCart()
    {

        var command = new ClearCartCommand();
        await _mediator.Send(command);
        return RedirectToAction("Index");
    }
    [HttpPost]
    [Route("RemoveFromCart")]
    public async Task<IActionResult> RemoveFromCart(Guid cardId)
    {
        var command = new RemoveFromCartCommand { CardId = cardId };
        await _mediator.Send(command);
        return RedirectToAction("Index");
    }
}