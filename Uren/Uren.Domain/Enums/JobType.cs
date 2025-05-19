using System.ComponentModel;

namespace Finate.Domain.Enums;

/// <summary>
/// Тип работы по времени
/// </summary>
public enum JobType
{
    [Description("Full Time")]
    FullTime = 1,
    
    [Description("1/2 Time")]
    HalfTime = 2,
    
    [Description("1/4 Time")]
    HalfHalfTime = 3,
    
    [Description("Negotiable work time")]
    Negotiable = 4,
    
    [Description("Remote work")]
    Remote = 5
}