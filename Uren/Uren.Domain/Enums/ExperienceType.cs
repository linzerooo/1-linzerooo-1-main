using System.ComponentModel;

namespace Finate.Domain.Enums;

/// <summary>
/// Тип опыта
/// </summary>
public enum ExperienceType
{
    [Description("Education")]
    Education = 1,
    
    [Description("Work")]
    Work = 2
}