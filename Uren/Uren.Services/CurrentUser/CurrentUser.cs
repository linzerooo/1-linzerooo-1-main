using System.Security.Claims;
using Finate.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Finate.Services.CurrentUser;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : ICurrentUser
{
    public Guid UserId => Guid.Parse(httpContextAccessor.HttpContext?.User.Claims
        .First(x => x.Type == ClaimTypes.NameIdentifier).Value!);

    public string Role => httpContextAccessor.HttpContext?.User.Claims
        .First(x => x.Type == ClaimTypes.Role).Value!;
}