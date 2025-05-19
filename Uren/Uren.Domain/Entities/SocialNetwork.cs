using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

/// <summary>
/// Социальная сеть
/// </summary>
public class SocialNetwork
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public User User { get; set; } = default!;
    
    /// <summary>
    /// Социальная сеть
    /// </summary>
    public SocialNetworkType SocialNetworkType { get; set; }

    /// <summary>
    /// Ссылка на соц. сеть
    /// </summary>
    public string Link { get; set; } = default!;
}