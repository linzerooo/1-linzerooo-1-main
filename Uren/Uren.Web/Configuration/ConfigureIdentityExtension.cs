using Finate.Domain.Entities;
using Finate.Persistence;
using Microsoft.AspNetCore.Identity;

namespace Finate.Web.Configuration;

public static class ConfigureIdentityExtension
{
    private const string AllowAnyCharactersWithRus =
        " абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ" +
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    
    /// <summary>
    /// Подключение Microsoft Identity
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IdentityBuilder AddIdentity(this IServiceCollection services)
    {
        return services.AddIdentity<User, Role>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.User.AllowedUserNameCharacters = AllowAnyCharactersWithRus;
            })
            .AddEntityFrameworkStores<DbContext>()
            .AddDefaultTokenProviders();
    }


}