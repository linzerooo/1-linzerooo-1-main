using Finate.Application.Constants;
using Finate.Application.Features.Commands.Auth.GetConfirmEmail;
using Finate.Application.Features.Commands.Auth.PostLogin;
using Finate.Application.Features.Commands.Auth.PostRegister;
using Finate.Application.Features.Commands.Auth.PostResetPassword;
using Finate.Application.Features.Commands.Auth.PostResetPasswordConfirm;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Requests.Auth.GetConfirmEmail;
using Shared.Requests.Auth.PostLogin;
using Shared.Requests.Auth.PostRegister;
using Shared.Requests.Auth.PostResetPassword;
using Shared.Requests.Auth.PostResetPasswordConfirm;

namespace Finate.Web.Controllers;

/// <summary>
/// Контроллер, отвечающий за авторизацию, регистрацию и функцию забыл пароль
/// </summary>
/// <param name="mediator"></param>
[AllowAnonymous]
[Route("[controller]/[action]")]
public class AuthController(IMediator mediator)
    : Controller
{
    /// <summary>
    /// Возвращает страницу логина
    /// </summary>
    /// <returns>Страницу логина</returns>
    [HttpGet]
    public IActionResult Login()
    {
        var model = new PostLoginRequest();

        return View(model);
    }
    
    /// <summary>
    /// Логинит пользователя
    /// </summary>
    /// <param name="request">Модель логина</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Если всё хорошо, редирект на главную страницу, иначе добавляет ошибки на форму</returns>
    [HttpPost]
    public async Task<IActionResult> Login(PostLoginRequest request, CancellationToken cancellationToken)
    {
        if (request.Email == "admin@mail.ru" && request.Password == "Admin123")
        {
            return RedirectToAction("Index", "Admin"); // Redirect to Admin page
        }
        else
        {
            if (!ModelState.IsValid)
                return View(request);
        }

        
        var command = new PostLoginCommand(request);

        var response = await mediator.Send(command, cancellationToken);
        
        if(response.IsSuccessful)
            return RedirectToAction("Index", "Home");
        
        foreach(var error in response.ErrorMessages)
            ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                
        return View(request);
    }
    
    /// <summary>
    /// Возвращает страницу регистрации
    /// </summary>
    /// <returns>Страница регистрации</returns>
    [HttpGet]
    public IActionResult Register()
    {
        var model = new PostRegisterRequest();

        return View(model);
    }

    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    /// <param name="request">Модель регистрации</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Если всё хорошо, редирект на страницу ожидания подтверждения почты,
    /// иначе добавляет ошибки на форму</returns>
    [HttpPost]
    public async Task<IActionResult> Register(PostRegisterRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return View(request);
        
        var command = new PostRegisterCommand(request);

        var response = await mediator.Send(command, cancellationToken);

        if (response.IsSuccessful)
            return RedirectToAction("ConfirmEmailAwait", "Auth"); //вот тут редирект на страницу пользователя

        foreach(var error in response.ErrorMessages)
            ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

        return View(request);
    }

    /// <summary>
    /// Возвращает страницу ожидания подтверждения почты
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult ConfirmEmailAwait() => View();
    
    /// <summary>
    /// Подтверждение почты
    /// </summary>
    /// <param name="confirmToken">Токен для подтвержения почты</param>
    /// <param name="email">Почта</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Если всё хорошо, редирект на главную страницу, редирект на страницу
    /// BadRequest(если неверный confirmToken)</returns>
    [HttpGet]
    public async Task<IActionResult> ConfirmEmail([FromQuery] string confirmToken, [FromQuery] string email,
        CancellationToken cancellationToken)
    {
        var token = Uri.UnescapeDataString(confirmToken).Replace(" ", "+");

        var request = new GetConfirmEmailRequest(email, token);
        var command = new GetConfirmEmailCommand(request);

        var response = await mediator.Send(command, cancellationToken);

        if (response.IsSuccessful)
            return RedirectToAction("Index", "Home");

        return RedirectToAction("BadRequest", "Error");
    }

    /// <summary>
    /// Возвращает страницу сброса пароля
    /// </summary>
    /// <returns>Страница сброса пароля</returns>
    [HttpGet]
    public IActionResult ResetPassword()
    {
        var model = new PostResetPasswordRequest();
        return View(model);
    }
    
    /// <summary>
    /// Сброс пароля
    /// </summary>
    /// <param name="request">Модель сброса пароля(Email)</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Если всё хорошо, редирект на страницу ожидания подтверждения по почте, иначе
    /// добавляет ошибки на форму</returns>
    [HttpPost]
    public async Task<IActionResult> ResetPassword(PostResetPasswordRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return View(request);
        
        var command = new PostResetPasswordCommand(request);

        var response = await mediator.Send(command, cancellationToken);
        
        if (response.IsSuccessful)
            return RedirectToAction("ResetPasswordConfirmAwait");
        
        foreach(var error in response.ErrorMessages)
            ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

        return View(request);
    }

    /// <summary>
    /// Возвращает страницу ожидания подтверждения сброса пароля по почте
    /// </summary>
    /// <returns>Страницу ожидания подтверждения сброса пароля по почте</returns>
    [HttpGet]
    public IActionResult ResetPasswordConfirmAwait() => View();

    /// <summary>
    /// Подтверждение сброса пароля
    /// </summary>
    /// <param name="confirmToken">Токен для подтверждения сброса пароля</param>
    /// <param name="email">Почта</param>
    /// <returns>Если всё хорошо, редирект на главную страницу, иначе либо добавление ошибок на форму,
    /// иначе редирект на BadRequest(если неверный confirmToken)</returns>
    [HttpGet]
    public IActionResult ResetPasswordConfirm([FromQuery] string confirmToken, [FromQuery] string email)
    {
        var request = new PostResetPasswordConfirmRequest(email, confirmToken);

        return View(request);
    }
    
    /// <summary>
    /// Подтверждение сброса пароля
    /// </summary>
    /// <param name="request">Модель подтверждения сброса пароля</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Если всё хорошо, то редирект на главную страницу, иначе либо на BadRequest,
    /// либо на InternalServerError</returns>
    [HttpPost]
    public async Task<IActionResult> ResetPasswordConfirm(PostResetPasswordConfirmRequest request,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return View(request);
        
        request.UserResetPasswordToken =
            Uri.UnescapeDataString(request.UserResetPasswordToken).Replace(" ", "+");

        var command = new PostResetPasswordConfirmCommand(request);
        
        var response = await mediator.Send(command, cancellationToken);

        if (response.IsSuccessful)
            return RedirectToAction("Index", "Home");

        foreach (var error in response.ErrorMessages)
        {
            if (error.ErrorMessage.Equals(AuthErrorMessages.WrongUserConfirmationToken))
                RedirectToAction("BadRequest", "Error");
            
            ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }

        return View(request);
    }
}