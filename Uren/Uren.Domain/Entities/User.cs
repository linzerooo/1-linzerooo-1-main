using Microsoft.AspNetCore.Identity;

namespace Finate.Domain.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class User : IdentityUser<Guid>
{
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime? BirthDay { get; set; }
    
    /// <summary>
    /// Ссылка на фото
    /// </summary>
    public string? UserPhotoUrl { get; set; }

    /// <summary>
    /// Список социальных сетей
    /// </summary>
    public List<SocialNetwork> SocialNetworks { get; set; } = [];
}