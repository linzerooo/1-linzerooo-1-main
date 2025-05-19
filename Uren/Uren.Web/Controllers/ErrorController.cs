using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finate.Web.Controllers;

/// <summary>
/// Контроллер отвечающий за отдачу страниц с ошибками
/// </summary>
[AllowAnonymous]
[Route("[controller]/[action]")]
public class ErrorController : Controller
{
    [HttpGet]
    public new IActionResult BadRequest()
        => View();

    [HttpGet]
    public new IActionResult NotFound()
        => View();

    [HttpGet]
    public IActionResult SomethingWentWrong()
        => View();
}