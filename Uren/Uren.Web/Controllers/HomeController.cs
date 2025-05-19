using Finate.Application.Features.Queries.Shop;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Requests.Home.GetIndex;
using Shared.Requests.Shop.GetShop;

namespace Finate.Web.Controllers;

/// <summary>
/// Контроллер отвечающий за отдачу главной страницы
/// </summary>
[Route("[controller]")]
public class HomeController : Controller
{
    private readonly IMediator _mediator;
    private static List<ShopModel> _shopData; // Используем статическое поле для хранения данных

    public HomeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("")]
    [Route("Home")]
    [Route("Home/Index")]
    public async Task<IActionResult> Index(CancellationToken cancellationToken, string sort = "asc")
    {
        var query = new GetShop();
        _shopData = await _mediator.Send(query, cancellationToken);

        // Apply sorting based on the sort parameter
        _shopData = sort.ToLower() == "desc"
            ? _shopData.OrderByDescending(s => s.Price).ToList()
            : _shopData.OrderBy(s => s.Price).ToList();

        ViewData["SortOrder"] = sort;

        return View(_shopData);
    }

    [HttpGet]
    [Route("Home/CardDetails/{cardId}")]
    public IActionResult CardDetails(Guid cardId)
    {
        var card = _shopData?.FirstOrDefault(c => c.Id == cardId); // Используем статическое поле для доступа к данным

        if (card == null)
        {
            return NotFound(); // Возвращаем ошибку 404, если карточка не найдена
        }

        return View(card); // Передаем модель карточки в представление CardDetails
    }
}
