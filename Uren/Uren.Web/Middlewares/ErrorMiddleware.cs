namespace Finate.Web.Middlewares;

/// <summary>
/// Middleware отвечающий за отдачу страниц с ошибками
/// </summary>
public class ErrorMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await next(context);
        
        switch (context.Response.StatusCode)
        {
            case 401:
                context.Response.Redirect("Auth/Login");
                break;
            case 404:
                context.Response.Redirect("Error/NotFound");
                break;
            case 400:
                context.Response.Redirect("Error/BadRequest");
                break;
            case 500:
                context.Response.Redirect("Error/SomethingWentWrong");
                break;
        }
    }
}