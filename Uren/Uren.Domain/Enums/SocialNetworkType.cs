using System.ComponentModel;

namespace Finate.Domain.Enums;

/// <summary>
/// Тип социальной сети
/// </summary>
public enum SocialNetworkType
{
    [Description("VK")]
    Vk = 1,
    
    [Description("Discord")]
    Discord = 2,
    
    [Description("Facebook")]
    Facebook = 3,
    
    [Description("Telegram")]
    Telegram = 4,
    
    [Description("Instagram")]
    Instagram = 5
}